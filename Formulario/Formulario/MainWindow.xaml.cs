using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using System.Windows;
using System.Windows.Controls;

namespace Formulario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UITextBoxInfo.Text = "";
            try
            {
                string name = UITextBoxName.Text;
                int age = Int32.Parse(UITextBoxAge.Text);
                string description = UITextBoxDescription.Text;
                AppManager.Instance.Students.Add(new Student(name, age, description));
            }
            catch
            {
                string messageBoxText = "Edad invalida perro.";
                string caption = "ERROR";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            ShowStudents();
        }

        void Save()
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, ShowStudents());
        }

        void Load()
        {
            string s = "";
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
               s = File.ReadAllText(openFileDialog.FileName);
            try
            {
                var json = JsonSerializer.Deserialize<List<Student>>(s);
                if(json != null)
                    AppManager.Instance.Students = json;
            }
            catch
            {
                string messageBoxText = "Tipo de archivo inválido";
                string caption = "ERROR";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            
            ShowStudents();
        }

        string ShowStudents()
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            UITextBoxInfo.Text = JsonSerializer.Serialize(AppManager.Instance.Students, options);
            return UITextBoxInfo.Text;
        }

        private void UITextBoxAge_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Save();
        }
    }
}
