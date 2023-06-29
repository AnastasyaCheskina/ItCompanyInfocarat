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
    /// Логика взаимодействия для MarkCompletionPage.xaml
    /// </summary>
    public partial class MarkCompletionPage : Window
    {
        public MarkCompletionPage()
        {
            InitializeComponent();
            name.Text = StaticResources.User.name;
            client.Text = StaticResources.Applications.Clients.name;
            adress.Text = StaticResources.Applications.Clients.adress;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalAccount personalAccount = new PersonalAccount();
            personalAccount.Show();
        }
        private void ReturnAtMainPage(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainPageEmployees mainPageEmployees = new MainPageEmployees();
            mainPageEmployees.Show();
        }
        private void SaveApplication(object sender, RoutedEventArgs e)
        {
            if (time.SelectedItem != null)
            {
                string timeStr = time.Text+":00";
                if (timeStr != null || timeStr != "")
                {
                    Done_applications application = new Done_applications();
                    application.id_application = StaticResources.Applications.id_application;
                    TimeSpan time = TimeSpan.Parse(timeStr);
                    application.time = time;
                    StaticResources.db.Done_applications.Add(application);
                    StaticResources.db.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены");
                    this.Hide();
                    MainPageEmployees mainPageEmployees = new MainPageEmployees();
                    mainPageEmployees.Show();
                }
                else MessageBox.Show("Произошла ошибка. Перепроверьте данные");
            }
            else MessageBox.Show("Укажите время выполнения");
        }
    }
}
