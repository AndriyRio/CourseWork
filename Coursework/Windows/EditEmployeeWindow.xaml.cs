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

namespace Coursework
{
    /// <summary>
    /// Interaction logic for EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IRankRepository RankRepository { get; set; }
        public Employee employee { get; set; }

        public EditEmployeeWindow()
        {
            InitializeComponent();
        }

        public void SetValues()
        {
            RanksComboBox.ItemsSource = RankRepository.GetAll();
            RanksComboBox.Text = employee.Rank.rank1.ToString();
            FirstNameTextBox.Text = employee.firstName;
            LastNameTextBox.Text = employee.lastName;
            DateOfBirthDataPiker.SelectedDate = employee.dataOfBirth;
            PhoneNumberTextBox.Text = employee.phoneNumber;
            AddresTextBox.Text = employee.address;
            HireDateDataPiker.SelectedDate = employee.hireDate;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeRepository.Edit(employee, FirstNameTextBox.Text, LastNameTextBox.Text, (DateTime)DateOfBirthDataPiker.SelectedDate,
                    PhoneNumberTextBox.Text, AddresTextBox.Text, (DateTime)HireDateDataPiker.SelectedDate, (Rank)RanksComboBox.SelectedItem);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка редагуання! Можливо ви ввели невірні дані.", "Помилка редагування", MessageBoxButton.OK, MessageBoxImage.None);
            }
}


    }
}
