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
    /// Логика взаимодействия для StatisticForAdmin.xaml
    /// </summary>
    public partial class StatisticForAdmin : Window
    {
        public StatisticForAdmin()
        {
            InitializeComponent();
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
            MainPageAdmin mainPageAdmin = new MainPageAdmin();
            mainPageAdmin.Show();
        }
        private void ReturnBack(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GetStatisticAdmin getStatisticAdmin = new GetStatisticAdmin();
            getStatisticAdmin.Show();
        }
    }
}
