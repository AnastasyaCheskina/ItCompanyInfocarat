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
using ItCompanyInfocarat.Model;

namespace ItCompanyInfocarat
{
    /// <summary>
    /// Логика взаимодействия для MainPageEmployees.xaml
    /// </summary>
    public partial class MainPageEmployees : Window
    {
        public MainPageEmployees()
        {
            InitializeComponent();
            name.Text = StaticResources.User.name + " " + StaticResources.User.patronymic;
            DataContext = this;
            List<Applications> applications = GetData(StaticResources.User.id_employee);
            allApplications.ItemsSource = applications;
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
            GetStatisticEmployee statisticEmployee = new GetStatisticEmployee();
            statisticEmployee.Show();
        }
        private List<Applications> GetData(int id_user) //получить список не выполненных заявок на сегодняшний день
        {
            DateTime? date = DateTime.Today;
            List<Done_applications> done_Applications = StaticResources.db.Done_applications.ToList();
            List<int> allId = new List<int>();
            foreach (var application in done_Applications)
            {
                allId.Add(application.id_application);
            }
            List<Applications> allApplications = StaticResources.db.Applications.Where(x => x.data == date && x.id_employee == id_user).ToList();
            List<Applications> applications = new List<Applications>();
            foreach (var application in allApplications)
            {
                if (!(allId.Contains(application.id_application)))
                {
                    applications.Add(application);
                }
            }
            return applications;
        }

        private void MarkCompletion(object sender, RoutedEventArgs e) //отметить выполнение заявки
        {
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Tag);
            Applications application = StaticResources.db.Applications.FirstOrDefault(x => x.id_application == id);
            if (application != null)
            {
                StaticResources.Applications = application;
                MarkCompletionPage completionPage = new MarkCompletionPage();
                this.Hide();
                completionPage.Show();
            }
            else MessageBox.Show("Произошла непредвиденная ошибка");
        }
    }
}
