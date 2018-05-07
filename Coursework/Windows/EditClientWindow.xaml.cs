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
    /// Interaction logic for EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        public IClientRepository ClientRepository { get; set; }
    
        public Сlient client { get; set; }

        public EditClientWindow()
        {
            InitializeComponent();
        }

        public void SetValues()
        {
                FirstNameTextBox.Text = client.firstName;
                LastNameTextBox.Text = client.lastName;
                DateOfBirthDataPiker.SelectedDate = client.dateOfBirth;
                PhoneNumberTextBox.Text = client.phoneNumber;
                AddresTextBox.Text = client.address;
                EmailTextBox.Text = client.e_mail;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ClientRepository.Edit(client, FirstNameTextBox.Text, LastNameTextBox.Text,
                    DateOfBirthDataPiker.SelectedDate, PhoneNumberTextBox.Text, AddresTextBox.Text, EmailTextBox.Text);

                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Помилка редагування! Можливо ви ввели невірні дані.", "Помилка редагування", MessageBoxButton.OK, MessageBoxImage.None);
            }
}
    }
}
