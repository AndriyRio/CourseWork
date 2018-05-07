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
    /// Interaction logic for OrderEmployeesWindow.xaml
    /// </summary>
    public partial class OrderEmployeesWindow : Window
    {
        public IOrderRepository OrderRepository { get; set; }
        public Order Order { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }

        public OrderEmployeesWindow()
        {
            InitializeComponent();
        }

        public void SetValues()
        {
            AddEmployeeComboBox.ItemsSource = EmployeeRepository.GetAll();
            RemoveEmployeeComboBox.ItemsSource = Order.Employees.ToList();
        }

        //Подія вилучення працівника з замовлення
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = (Employee)AddEmployeeComboBox.SelectedItem;
                if (employee == null)
                {
                    MessageBox.Show("Виберіть працівника зі списку працівників, які працюют над даним замовленням", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
                    return;
                }
                Order.Employees.Add(employee);
                OrderRepository.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати працівника до замовлення!", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }

        //Подія призначення працівника на замовлення
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = (Employee)RemoveEmployeeComboBox.SelectedItem;
                if (employee == null)
                {
                    MessageBox.Show("Виберіть працівника", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
                    return;
                }
                Order.Employees.Remove(employee);
                OrderRepository.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати працівника до замовлення!", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
