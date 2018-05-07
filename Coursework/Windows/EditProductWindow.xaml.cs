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
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public IProductRepository ProductRepository { get; set; }
        public IManufacturerRepository ManufacturerRepository { get; set; }
        public ICategorieRepository CategorieRepository { get; set; }
        public Product Product { get; set; }

        public EditProductWindow()
        {
            InitializeComponent();
        }
        public void SetValues()
        {
            ManufacturerComboBox.ItemsSource = ManufacturerRepository.GetAll();
            CategorieComboBox.ItemsSource = CategorieRepository.GetAll();
            ManufacturerComboBox.Text = Product.Manufacturer.name;
            CategorieComboBox.Text = Product.Categorie.name;
            NameTextBox.Text = Product.name;
            PriceTextBox.Text = Product.price.ToString();
            ManufacturedDatePiker.SelectedDate = Product.manufacturedDate;
            ImportDatePiker.SelectedDate = Product.importDate;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductRepository.Edit(Product, NameTextBox.Text, (Categorie)CategorieComboBox.SelectedItem,
                    ManufacturedDatePiker.SelectedDate, ImportDatePiker.SelectedDate, Int32.Parse(PriceTextBox.Text), 
                    (Manufacturer)ManufacturerComboBox.SelectedItem);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка редагування! Можливо ви ввели невірні дані.", "Помилка редагування", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
