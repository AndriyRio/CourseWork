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
    /// Interaction logic for NewClientWindow.xaml
    /// </summary>
    public partial class NewClientWindow : Window
    {
        public IClientRepository ClientRepository { get; set; }

        public NewClientWindow()
        {
            InitializeComponent();
        }

        // Подія додавання клієнта
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Сlient client = new Сlient();
                client.firstName = FirstNameTextBox.Text;
                client.lastName = LastNameTextBox.Text;
                client.dateOfBirth = DateOfBirthDataPiker.SelectedDate;
                client.phoneNumber = PhoneNumberTextBox.Text;
                client.e_mail = EmailTextBox.Text;
                client.address = AddresTextBox.Text;

                ClientRepository.Add(client);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати клієнта! Можливо ви ввели невірні дані.", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
