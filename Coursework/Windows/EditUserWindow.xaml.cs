using Coursework.Repository;
using Coursework.Repository.Impl;
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
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public IUserRepository UserRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public User user { get; set; }

        public EditUserWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserRepository.Edit(user, LoginTextBox.Text, PasswordTextBox.Text, (Role)RolesComboBox.SelectedItem);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка редагування! Можливо ви ввели невірні дані.", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
}

        public void SetValues()
        {
            RolesComboBox.ItemsSource = RoleRepository.GetAll();
            RolesComboBox.Text = user.Role.userRole;
            LoginTextBox.Text = user.login;
            PasswordTextBox.Text = user.password;
        }
    }
}
