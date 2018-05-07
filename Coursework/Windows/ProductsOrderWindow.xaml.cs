using Coursework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Coursework.Windows
{
    /// <summary>
    /// Interaction logic for ProductsOrderWindow.xaml
    /// </summary>
    public partial class ProductsOrderWindow : Window
    {
        public IOrderRepository OrderRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public Order Order { get; set; }

        public ProductsOrderWindow()
        {
            InitializeComponent();
        }

        public void SetValues()
        {
            AddProductComboBox.ItemsSource = ProductRepository.GetAll();
            RemoveProductComboBox.ItemsSource = Order.Products.ToList();
        }

        //Додавання товару до замовлення
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = (Product)AddProductComboBox.SelectedItem;
                if (product == null)
                {
                    MessageBox.Show("Виберіть товар", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
                    return;
                }
                Order.Products.Add(product);
                OrderRepository.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати товар до замовлення!", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }

        }

        //Вилучення товару з замовлення
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = (Product)RemoveProductComboBox.SelectedItem;
                if (product == null)
                {
                    MessageBox.Show("Виберіть товар", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
                    return;
                }
                Order.Products.Remove(product);
                OrderRepository.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати товар до замовлення!", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
