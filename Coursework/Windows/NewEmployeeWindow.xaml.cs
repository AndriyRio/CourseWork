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
    /// Interaction logic for NewEmployeeWindow.xaml
    /// </summary>
    public partial class NewEmployeeWindow : Window
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IRankRepository RankRepository { get; set; }

        public NewEmployeeWindow()
        {
            InitializeComponent();
        }

        public void SetRolesComboBox()
        {
            RanksComboBox.ItemsSource = RankRepository.GetAll();
        }

        //Подія кнопки для додавання працівника
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.firstName = FirstNameTextBox.Text;
                employee.lastName = LastNameTextBox.Text;
                employee.dataOfBirth = (DateTime)DateOfBirthDataPiker.SelectedDate;
                employee.phoneNumber = PhoneNumberTextBox.Text;
                employee.address = AddresTextBox.Text;
                employee.hireDate = (DateTime)HireDateDataPiker.SelectedDate;
                Rank rank = (Rank)RanksComboBox.SelectedItem;
                employee.Rank = rank;
                employee.rankID = rank.rankID;

                EmployeeRepository.Add(employee);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невдалось додати працівника! Можливо ви ввели невірні дані.", "Помилка додавання", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
    
}
