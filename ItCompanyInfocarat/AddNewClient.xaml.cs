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
    /// Логика взаимодействия для AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        public AddNewClient()
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
            MainPageAdmin admin = new MainPageAdmin();
            admin.Show();
        }
        private void SaveClient(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || nameDirector.Text == "" || phone.Text == "" || adress.Text == "")
            {
                MessageBox.Show("Вы заполнили не все данные");
            }
            else
            {
                Clients client = new Clients
                {
                    name = name.Text,
                    name_director = nameDirector.Text,
                    phone = phone.Text,
                    adress = adress.Text,
                };
                StaticResources.db.Clients.Add(client);
                StaticResources.db.SaveChanges();
                MessageBox.Show("Данные успешно сохранены");
                this.Hide();
                MainPageAdmin mainPageAdmin = new MainPageAdmin();
                mainPageAdmin.Show();
            }
        }
    }
}
