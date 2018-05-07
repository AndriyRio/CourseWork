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
    /// Interaction logic for NewPaymentWindow.xaml
    /// </summary>
    public partial class NewPaymentWindow : Window
    {
        public IPaymentRepository PaymentRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IPaymentModeRepositoy PaymentModeRepositoy { get; set; }

        public NewPaymentWindow()
        {
            InitializeComponent();
        }

        public void SetValues()
        {
            OrderComboBox.ItemsSource = OrderRepository.GetAll();
            PaymentModeComboBox.ItemsSource = PaymentModeRepositoy.GetAll();
        }

        //Подія додавання платежу
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Payment payment = new Payment();
                payment.chequeDate = PaymentDatePicker.SelectedDate;
                payment.amountPaid = Decimal.Parse(AmountPaidComboBox.Text);
                Order order = (Order)OrderComboBox.SelectedItem;
                payment.Order = order;
                payment.orderID = order.orderID;
                PaymentMode paymentMode = (PaymentMode)PaymentModeComboBox.SelectedItem;
                payment.PaymentMode = paymentMode;
                payment.pmodeID = paymentMode.pmodeID;

                PaymentRepository.Add(payment);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати платіж! Можливо ви ввели невірні дані.", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
