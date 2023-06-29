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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItCompanyInfocarat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Employees user = StaticResources.db.Employees.FirstOrDefault(x => x.username == username.Text && password.Password == x.password);
            if (username.Text == "" || password.Password == "")
            {
                MessageBox.Show("Данные не были введены");
            }
            else
            {
                if (user != null)
                {
                    StaticResources.User = user;
                    MessageBox.Show("Вход успешно выполнен");
                    this.Hide();
                    if (user.id_role == 1) 
                    { 
                        MainPageAdmin mainPageAdmin = new MainPageAdmin();
                        mainPageAdmin.Show();
                    }
                    else 
                    {
                        MainPageEmployees mainPageEmployees = new MainPageEmployees();
                        mainPageEmployees.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Пользователя с такими данными не существует");
                }
            }
        }
    }
}
