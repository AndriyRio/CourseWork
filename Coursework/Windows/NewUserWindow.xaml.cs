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
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        public IUserRepository UserRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }

        public NewUserWindow()
        {
            InitializeComponent();
        }

        //Подія додавання користувача
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();
                user.login = LoginTextBox.Text;
                user.password = PasswordTextBox.Text;
                Role role = (Role)RolesComboBox.SelectedItem;
                user.Role = role;
                user.roleId = role.roleId;

                UserRepository.Add(user);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати користувача! Можливо ви ввели невірні дані.", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }

        public void SetRoles()
        {
            RolesComboBox.ItemsSource = RoleRepository.GetAll();
        }
    }
}
