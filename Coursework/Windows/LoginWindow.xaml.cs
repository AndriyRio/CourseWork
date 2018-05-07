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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static ShopOfJoinerArticlesDBEntities db = new ShopOfJoinerArticlesDBEntities();
        private IUserRepository userRepository;

        public LoginWindow()
        {
            InitializeComponent();
            userRepository = new UserRepositoryImpl(db);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = null;
            try
            {
                user = userRepository.FindByLoginAndPassword(LoginTextBox.Text, PasswordBox.Password);
                MainWindow mainWindow = new MainWindow();
                mainWindow.User = user;
                mainWindow.UserLabel.Content = user.ToString();
                if (user.Role.userRole.Equals("Personal"))
                {
                    mainWindow.PaymnetsTabItem.Visibility = Visibility.Collapsed;
                    mainWindow.CategorieTabItem.Visibility = Visibility.Collapsed;
                    mainWindow.UserTabItem.Visibility = Visibility.Collapsed;
                }
                if (user.Role.userRole.Equals("Manager"))
                {
                    mainWindow.CategorieTabItem.Visibility = Visibility.Collapsed;
                    mainWindow.UserTabItem.Visibility = Visibility.Collapsed;
                }
                
                mainWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправльний логін або парооль!");
            }
        }
    }
}
