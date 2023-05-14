using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }


    public partial class MainWindow : Window
    {
        List<Product> pp;
        ObservableCollection<Product> products = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product()
                {
                    Name = "Juan " + i,
                    Description = "Chocolate sexy " + i
                });
            }

            ListViewProducts.ItemsSource = products;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Product p = (Product)b.DataContext;
            //MessageBox.Show(p.Description);
            products.Add(new Product()
            {
                Name = "Gian",
                Description = "Franco"
            });
        }
    }
}
