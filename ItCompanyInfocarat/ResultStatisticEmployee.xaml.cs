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
    /// Логика взаимодействия для ResultStatisticEmployee.xaml
    /// </summary>
    public partial class ResultStatisticEmployee : Window
    {
        public ResultStatisticEmployee()
        {
            InitializeComponent();
            DataContext = this;
            allApplications.ItemsSource = StaticResources.DoneApplications;
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
        private void ReturnBack(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GetStatisticEmployee statisticEmployee = new GetStatisticEmployee();
            statisticEmployee.Show();
        }
    }
}
