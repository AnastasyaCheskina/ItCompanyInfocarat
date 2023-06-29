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
    /// Логика взаимодействия для GetStatisticAdmin.xaml
    /// </summary>
    public partial class GetStatisticAdmin : Window
    {
        public GetStatisticAdmin()
        {
            InitializeComponent();
            List<Employees> allEmployees = StaticResources.db.Employees.ToList();
            allEmployees.Remove(StaticResources.User);
            List<string> FIO = new List<string>();
            foreach (Employees employee in allEmployees)
            {
                FIO.Add(employee.name + " " + employee.surname);
            }
            employees.ItemsSource = FIO;
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
            MainPageAdmin mainPageAdmin = new MainPageAdmin();
            mainPageAdmin.Show();
        }
        private void ToResults(object sender, RoutedEventArgs e)
        {
            if (month.SelectedItem != null && year.SelectedItem != null && employees.SelectedItem != null)
            {
                string dataFirst = "01." + month.Text + "." + year.Text;
                string dataLast = "28." + month.Text + "." + year.Text;
                DateTime dateFirst = DateTime.Parse(dataFirst);
                DateTime dateLast = DateTime.Parse(dataLast);
                string[] FIO = employees.SelectedItem.ToString().Split(' ');
                string name = FIO[0], surname = FIO[1];
                Employees employee = StaticResources.db.Employees.FirstOrDefault(x => x.name == name && x.surname == surname);
                List<Done_applications> done_Applications = StaticResources.db.Done_applications.Where(x => x.Applications.id_employee == employee.id_employee && x.Applications.data >= dateFirst && x.Applications.data <= dateLast).ToList();
                StaticResources.DoneApplications = done_Applications;
                this.Hide();
                StatisticForAdmin statisticForAdmin = new StatisticForAdmin();
                statisticForAdmin.Show();
            }
            else MessageBox.Show("Вы выбрали не все данные");
        }
    }
}
