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
    /// Interaction logic for NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        public IOrderRepository OrderRepository { get; set; }
        public IClientRepository ClienRepository { get; set; }

        public NewOrderWindow()
        {
            InitializeComponent();
        }

        public void SetClientsComboBox()
        {
            ClientComboBox.ItemsSource = ClienRepository.GetAll();
        }

        //Подія додавання замовлення
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = new Order();
                order.orderDate = OrderDatePicker.SelectedDate;
                order.payDate = PayDatePicker.SelectedDate;
                order.paymentStatus = "Не оплачено";
                order.deliveredStatus = "Не доставлено";
                order.discount = Decimal.Parse(DiscountTextBox.Text);

                Сlient сlient = (Сlient)ClientComboBox.SelectedItem;
                order.Сlient = сlient;
                order.clientID = сlient.clientID;

                OrderRepository.Add(order);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати замовлення! Можливо ви ввели невірні дані.", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
