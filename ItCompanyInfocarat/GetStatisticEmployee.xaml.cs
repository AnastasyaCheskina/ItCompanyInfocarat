using ItCompanyInfocarat.Model;
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
    /// Логика взаимодействия для GetStatisticEmployee.xaml
    /// </summary>
    public partial class GetStatisticEmployee : Window
    {
        public GetStatisticEmployee()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalAccount personalAccount = new PersonalAccount();
            personalAccount.Show();
        }
        private void ToMainPage(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainPageEmployees mainPage = new MainPageEmployees();
            mainPage.Show();
        }
        private void ToResults(object sender, RoutedEventArgs e)
        {
            if (month.SelectedItem != null && year.SelectedItem != null)
            {
                string dataFirst = "01." + month.Text + "." + year.Text;
                string dataLast = "28." + month.Text + "." + year.Text;
                DateTime dateFirst = DateTime.Parse(dataFirst);
                DateTime dateLast = DateTime.Parse(dataLast);
                List<Done_applications> done_Applications = StaticResources.db.Done_applications.Where(x => x.Applications.data >= dateFirst && x.Applications.data <= dateLast && x.Applications.Employees.id_employee == StaticResources.User.id_employee).ToList();
                StaticResources.DoneApplications = done_Applications;
                this.Hide();
                ResultStatisticEmployee resultStatistic = new ResultStatisticEmployee();
                resultStatistic.Show();
            }
            else MessageBox.Show("Выбраны не все данные");
        }
    }
}
