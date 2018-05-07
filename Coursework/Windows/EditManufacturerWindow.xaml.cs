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
    /// Interaction logic for EditManufacturerWindow.xaml
    /// </summary>
    public partial class EditManufacturerWindow : Window
    {
        public IManufacturerRepository ManufacturerRepository { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public EditManufacturerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ManufacturerRepository.Edit(Manufacturer, NameTextBox.Text, EmailTextBox.Text, PhoneNumberTextBox.Text);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка редагування! Можливо ви ввели невірні дані.", "Помилка редагування", MessageBoxButton.OK, MessageBoxImage.None);
            }
}

        public void SetValues()
        {
            NameTextBox.Text = Manufacturer.name;
            EmailTextBox.Text = Manufacturer.e_mail;
            PhoneNumberTextBox.Text = Manufacturer.phoneNumber;
        }
    }
}
