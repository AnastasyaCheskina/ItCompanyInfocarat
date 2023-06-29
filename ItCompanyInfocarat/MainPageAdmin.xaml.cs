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

namespace ItCompanyInfocarat
{
    /// <summary>
    /// Логика взаимодействия для MainPageAdmin.xaml
    /// </summary>
    public partial class MainPageAdmin : Window
    {
        public MainPageAdmin()
        {
            InitializeComponent();
            name.Text = StaticResources.User.name + " " + StaticResources.User.patronymic;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalAccount personalAccount = new PersonalAccount();
            personalAccount.Show();
        }
        private void ToStatistic(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GetStatisticAdmin getStatisticAdmin = new GetStatisticAdmin();
            getStatisticAdmin.Show();
        }
        private void AddNewEmployees(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddNewEmployee addNewEmployee = new AddNewEmployee();
            addNewEmployee.Show();
        }
        private void AddNewApplications(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddNewAppl addNewAppl = new AddNewAppl();
            addNewAppl.Show();
        }
        private void AddNewClients(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddNewClient addNew = new AddNewClient();
            addNew.Show();
        }
        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DelEmployee delEmployee = new DelEmployee();
            delEmployee.Show();
        }
    }
}
