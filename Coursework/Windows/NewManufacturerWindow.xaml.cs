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
    /// Interaction logic for NewManufacturerWindow.xaml
    /// </summary>
    public partial class NewManufacturerWindow : Window
    {
        public IManufacturerRepository ManufacturerRepository { get; set; }

        public NewManufacturerWindow()
        {
            InitializeComponent();
        }

        //Подія додавання виробника 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Manufacturer manufacturer = new Manufacturer();
                manufacturer.name = NameTextBox.Text;
                manufacturer.e_mail = EmailTextBox.Text;
                manufacturer.phoneNumber = PhoneNumberTextBox.Text;

                ManufacturerRepository.Add(manufacturer);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати виробника! Можливо ви ввели невірні дані.", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
