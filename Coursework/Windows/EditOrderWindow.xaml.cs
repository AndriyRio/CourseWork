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
    /// Interaction logic for EditOrderWindow.xaml
    /// </summary>
    public partial class EditOrderWindow : Window
    {
        public IOrderRepository OrderRepository { get; set; }
        public IClientRepository ClienRepository { get; set; }
        public Order Order { get; set; }

        public EditOrderWindow()
        {
            InitializeComponent();
            PaymentStatusComboBox.Items.Add("Оплачено");
            PaymentStatusComboBox.Items.Add("Не оплачено");

            DeliveredStatusComboBox.Items.Add("Доставлено");
            DeliveredStatusComboBox.Items.Add("Не доставлено");
        }

        public void SetValues()
        {
            ClientComboBox.ItemsSource = ClienRepository.GetAll();
            ClientComboBox.SelectedItem = Order.Сlient;
            PaymentStatusComboBox.Text = Order.paymentStatus;
            DeliveredStatusComboBox.Text = Order.deliveredStatus;
            OrderDatePicker.SelectedDate = Order.orderDate;
            PayDatePicker.SelectedDate = Order.payDate;
            DiscountTextBox.Text = Order.discount.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderRepository.Edit(Order,OrderDatePicker.SelectedDate, PayDatePicker.SelectedDate, Decimal.Parse(DiscountTextBox.Text),
                  (Сlient)ClientComboBox.SelectedItem, PaymentStatusComboBox.Text, DeliveredStatusComboBox.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка редагування! Можливо ви ввели невірні дані.", "Помилка редагування", MessageBoxButton.OK, MessageBoxImage.None);
            }
}
    }
}
