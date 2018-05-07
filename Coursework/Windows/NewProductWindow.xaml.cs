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
    /// Interaction logic for NewProductWindow.xaml
    /// </summary>
    public partial class NewProductWindow : Window
    {
        public IProductRepository ProductRepository { get; set; }
        public IManufacturerRepository ManufacturerRepository { get; set; }
        public ICategorieRepository CategorieRepository { get; set; }

        public NewProductWindow()
        {
            InitializeComponent();
        }

        public void SetManufacturerAndCategorieComboBox()
        {
            ManufacturerComboBox.ItemsSource = ManufacturerRepository.GetAll();
            CategorieComboBox.ItemsSource = CategorieRepository.GetAll();
        }

        //Подія додавання товару
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();
                product.name = NameTextBox.Text;
                product.manufacturedDate = ManufacturedDatePiker.SelectedDate;
                product.importDate = ImportDatePiker.SelectedDate;
                product.price = Int32.Parse(PriceTextBox.Text);
                Categorie categorie = (Categorie)CategorieComboBox.SelectedItem;
                product.Categorie = categorie;
                product.categoryID = categorie.categoryID;
                Manufacturer manufacturer = (Manufacturer)ManufacturerComboBox.SelectedItem;
                product.Manufacturer = manufacturer;
                product.manufaturerID = manufacturer.manufactureID;

                ProductRepository.Add(product);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати товар! Можливо ви ввели невірні дані.", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
