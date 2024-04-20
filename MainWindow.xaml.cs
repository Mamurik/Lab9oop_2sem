using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;

namespace Lab9oop
{
    public partial class MainWindow : Window
    {
        private string selectedFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(selectedFilePath);
                FileContentTextBox.Text = fileContent;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                double sum = File.ReadAllText(selectedFilePath)
                    .Split(' ')
                    .Select(numStr => double.Parse(numStr, new CultureInfo("ru-RU")))
                    .Where(num => num % 2 == 0)
                    .Sum();

                // Выводим результат на экран
                MessageBox.Show($"Сумма четных чисел: {sum}");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите файл.");
            }
        }
    }
}