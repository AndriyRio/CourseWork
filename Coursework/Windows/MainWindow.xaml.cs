using Coursework.Repository;
using Coursework.Repository.Impl;
using Coursework.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User User { get; set; }

        private static ShopOfJoinerArticlesDBEntities db = new ShopOfJoinerArticlesDBEntities();

        private IEmployeeRepository employeeRepository;
        private IOrderRepository orderRepository;
        private IClientRepository clientRepository;
        private IProductRepository productRepository;
        private IManufacturerRepository manufacturerRepository;
        private IRoleRepository roleRepository;
        private IRankRepository rankRepository;
        private ICategorieRepository categorieRepository;
        private IPaymentRepository paymentRepository;
        private IPaymentModeRepositoy paymentModeRepositoy;
        private IUserRepository userRepository;

        public MainWindow()
        {
            InitializeComponent();

            employeeRepository = new EmployeeRepositoryImpl(db);
            orderRepository = new OrderRepositoryImpl(db);
            clientRepository = new ClientRepositoryImpl(db);
            productRepository = new ProductRepositoryImpl(db);
            manufacturerRepository = new ManufacturerRepositoryImpl(db);
            roleRepository = new RoleRepositoryImpl(db);
            rankRepository = new RankRepositoryImpl(db);
            categorieRepository = new CategoyRepositoryImpl(db);
            paymentRepository = new PaymentRepositoryImpl(db);
            paymentModeRepositoy = new PaymentModeRepositoryImpl(db);
            userRepository = new UserRepositoryImpl(db);

            EmployeesDataGrid.ItemsSource = employeeRepository.GetAll();
            OrdersDataGrid.ItemsSource = orderRepository.GetAll();
            ClientsDataGrid.ItemsSource = clientRepository.GetAll();
            ProductsDataGrid.ItemsSource = productRepository.GetAll();
            ManufacturerDataGrid.ItemsSource = manufacturerRepository.GetAll();
            PaymentsDataGrid.ItemsSource = paymentRepository.GetAll();
            CategoriesDataGrid.ItemsSource = categorieRepository.GetAll();
            UsersDataGrid.ItemsSource = userRepository.GetAll();
        }

        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                EmployeeOrdersList.ItemsSource = ((Employee)EmployeesDataGrid.SelectedItem).Orders.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                OrderProductsDataGrid.ItemsSource = ((Order)OrdersDataGrid.SelectedItem).Products.ToList();
                OrderEmployeesDataGrid.ItemsSource = ((Order)OrdersDataGrid.SelectedItem).Employees.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin"))
            {
                NewEmployeeWindow newEmpWindow = new NewEmployeeWindow();
                newEmpWindow.EmployeeRepository = employeeRepository;
                newEmpWindow.RankRepository = rankRepository;
                newEmpWindow.SetRolesComboBox();

                newEmpWindow.ShowDialog();
                EmployeesDataGrid.ItemsSource = employeeRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void EditEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin"))
            {
                EditEmployeeWindow editEmpWindow = new EditEmployeeWindow();
                editEmpWindow.RankRepository = rankRepository;
                editEmpWindow.EmployeeRepository = employeeRepository;
                editEmpWindow.employee = (Employee)EmployeesDataGrid.SelectedItem;
                editEmpWindow.SetValues();
                editEmpWindow.ShowDialog();
                EmployeesDataGrid.ItemsSource = employeeRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }

        }

        private void RemoveEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin"))
            {
                string messageBoxText = "Ви дійсно хочете видалити працівника?";
                string caption = "Підтвердження видалення";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var employee = ((Employee)EmployeesDataGrid.SelectedItem);
                        try
                        {
                            employeeRepository.Delete(employee);
                        }
                        catch(Exception exception)
                        {
                            MessageBox.Show("Невдалось видалити працівика! Даний працівник залучений до замовлення.");
                        }
                        EmployeesDataGrid.ItemsSource = employeeRepository.GetAll();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }

        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //Дозвіл на додавання замовлення для адміністратора та менеджерп
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                NewOrderWindow orderWindow = new NewOrderWindow();
                orderWindow.OrderRepository = orderRepository;
                orderWindow.ClienRepository = clientRepository;
                orderWindow.SetClientsComboBox();

                orderWindow.ShowDialog();
                OrdersDataGrid.ItemsSource = orderRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void RemoveOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //Дозвіл на видалення замовлення тільки для адміністратора
            if (User.Role.userRole.Equals("Admin"))
            {
                string messageBoxText = "Ви дійсно хочете видалити замовлення?";
                string caption = "Підтвердження видалення";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var order = ((Order)OrdersDataGrid.SelectedItem);
                        try
                        {
                            orderRepository.Delete(order);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Невдалось видалити замовлення!");
                        }
                        OrdersDataGrid.ItemsSource = orderRepository.GetAll();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void EditOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //Дозвіл на редагування замовлення для адміністратора та менеджера
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                EditOrderWindow editOrderWindow = new EditOrderWindow();
                editOrderWindow.OrderRepository = orderRepository;
                editOrderWindow.ClienRepository = clientRepository;
                editOrderWindow.Order = (Order)OrdersDataGrid.SelectedItem;
                editOrderWindow.SetValues();
                editOrderWindow.ShowDialog();

                OrdersDataGrid.ItemsSource = orderRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void OrderEmpoyeesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                OrderEmployeesWindow orderEmployees = new OrderEmployeesWindow();
                orderEmployees.OrderRepository = orderRepository;
                orderEmployees.EmployeeRepository = employeeRepository;
                Order order = (Order)OrdersDataGrid.SelectedItem;
                orderEmployees.Order = order;
                orderEmployees.SetValues();

                orderEmployees.ShowDialog();
                try
                {
                    OrderEmployeesDataGrid.ItemsSource = ((Order)OrdersDataGrid.SelectedItem).Employees.ToList();
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void OrderProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                ProductsOrderWindow productsOrderWindow = new ProductsOrderWindow();
                productsOrderWindow.OrderRepository = orderRepository;
                productsOrderWindow.ProductRepository = productRepository;
                Order order = (Order)OrdersDataGrid.SelectedItem;
                productsOrderWindow.Order = order;
                productsOrderWindow.SetValues();

                productsOrderWindow.ShowDialog();
                try
                {
                    OrderProductsDataGrid.ItemsSource = ((Order)OrdersDataGrid.SelectedItem).Products.ToList();
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                NewClientWindow newClientWindow = new NewClientWindow();
                newClientWindow.ClientRepository = clientRepository;

                newClientWindow.ShowDialog();
                ClientsDataGrid.ItemsSource = clientRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void EditСlientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                EditClientWindow editEmpWindow = new EditClientWindow();
                editEmpWindow.ClientRepository = clientRepository;
                editEmpWindow.client = (Сlient)ClientsDataGrid.SelectedItem;
                editEmpWindow.SetValues();
                editEmpWindow.ShowDialog();
                ClientsDataGrid.ItemsSource = clientRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void RemoveClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin"))
            {
                string messageBoxText = "Ви дійсно хочете видалити клієнта?";
                string caption = "Підтвердження видалення";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var client = ((Сlient)ClientsDataGrid.SelectedItem);
                        try
                        {
                            clientRepository.Delete(client);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Невдалось видалити клієнта! Є дійсне замовлення з клієнтом.");
                        }
                        ClientsDataGrid.ItemsSource = clientRepository.GetAll();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {

            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                NewProductWindow newEmpWindow = new NewProductWindow();
                newEmpWindow.CategorieRepository = categorieRepository;
                newEmpWindow.ManufacturerRepository = manufacturerRepository;
                newEmpWindow.ProductRepository = productRepository;
                newEmpWindow.SetManufacturerAndCategorieComboBox();
                newEmpWindow.ShowDialog();
                ProductsDataGrid.ItemsSource = productRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void EditProductBtn_Cick(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                EditProductWindow editEmpWindow = new EditProductWindow();
                editEmpWindow.ProductRepository = productRepository;
                editEmpWindow.CategorieRepository = categorieRepository;
                editEmpWindow.ManufacturerRepository = manufacturerRepository;
                editEmpWindow.Product = (Product)ProductsDataGrid.SelectedItem;
                editEmpWindow.SetValues();
                editEmpWindow.ShowDialog();
                ProductsDataGrid.ItemsSource = productRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void RemoveProductBtn_Cick(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                string messageBoxText = "Ви дійсно хочете видалити товар?";
                string caption = "Підтвердження видалення";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var product = ((Product)ProductsDataGrid.SelectedItem);
                        productRepository.Delete(product);
                        ProductsDataGrid.ItemsSource = productRepository.GetAll();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void AddManufacturerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                NewManufacturerWindow newManWindow = new NewManufacturerWindow();
                newManWindow.ManufacturerRepository = manufacturerRepository;
                newManWindow.ShowDialog();
                ManufacturerDataGrid.ItemsSource = manufacturerRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void RemoveManufacturerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin"))
            {
                string messageBoxText = "Ви дійсно хочете видалити виробника?";
                string caption = "Підтвердження видалення";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var manufacturer = ((Manufacturer)ManufacturerDataGrid.SelectedItem);
                        try
                        {
                            manufacturerRepository.Delete(manufacturer);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Невдалось видалити виробника! На складі є товар від даного виробника");
                        }
                        ManufacturerDataGrid.ItemsSource = manufacturerRepository.GetAll();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void EditManufacturerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin") || User.Role.userRole.Equals("Manager"))
            {
                EditManufacturerWindow editManufacturerWindow = new EditManufacturerWindow();
                editManufacturerWindow.ManufacturerRepository = manufacturerRepository;
                editManufacturerWindow.Manufacturer = (Manufacturer)ManufacturerDataGrid.SelectedItem;
                editManufacturerWindow.SetValues();
                editManufacturerWindow.ShowDialog();
                ManufacturerDataGrid.ItemsSource = manufacturerRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void AddPaymentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin"))
            {
                NewPaymentWindow paymentWindow = new NewPaymentWindow();
                paymentWindow.OrderRepository = orderRepository;
                paymentWindow.PaymentRepository = paymentRepository;
                paymentWindow.PaymentModeRepositoy = paymentModeRepositoy;
                paymentWindow.SetValues();

                paymentWindow.ShowDialog();
                PaymentsDataGrid.ItemsSource = paymentRepository.GetAll();
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void RemovePaymetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin"))
            {
                string messageBoxText = "Ви дійсно хочете видалити платіж?";
                string caption = "Підтвердження видалення";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var payment = ((Payment)PaymentsDataGrid.SelectedItem);
                        paymentRepository.Delete(payment);
                        PaymentsDataGrid.ItemsSource = paymentRepository.GetAll();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void RemoveCategorieBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin"))
            {
                string messageBoxText = "Ви дійсно хочете видалити категорію?";
                string caption = "Підтвердження видалення";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var categorie = ((Categorie)CategoriesDataGrid.SelectedItem);
                        try
                        {
                            categorieRepository.Delete(categorie);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Невдалось видалити категорію! Є товар, який належить до даної категорії");
                        }
                        CategoriesDataGrid.ItemsSource = categorieRepository.GetAll();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void AddCategorieBtn_Click(object sender, RoutedEventArgs e)
        {
            NewCategorieWindow newCategorieWindow = new NewCategorieWindow();
            newCategorieWindow.CategorieRepository = categorieRepository;

            newCategorieWindow.ShowDialog();
            CategoriesDataGrid.ItemsSource = categorieRepository.GetAll();
        }

        private void RemoveUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (User.Role.userRole.Equals("Admin"))
            {
                string messageBoxText = "Ви дійсно хочете видалити користувача";
                string caption = "Підтвердження видалення";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        var user = ((User)UsersDataGrid.SelectedItem);
                        userRepository.Delete(user);
                        UsersDataGrid.ItemsSource = userRepository.GetAll();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("У вас недостатньо прав!");
            }
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow newUserWindow = new NewUserWindow();
            newUserWindow.UserRepository = userRepository;
            newUserWindow.RoleRepository = roleRepository;
            newUserWindow.SetRoles();

            newUserWindow.ShowDialog();
            UsersDataGrid.ItemsSource = userRepository.GetAll();
        }

        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUserWindow = new EditUserWindow();
            editUserWindow.user = (User)UsersDataGrid.SelectedItem;
            editUserWindow.UserRepository = userRepository;
            editUserWindow.RoleRepository = roleRepository;
            editUserWindow.SetValues();

            editUserWindow.ShowDialog();
            UsersDataGrid.ItemsSource = userRepository.GetAll();
        }
    }
}
