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
    /// Логика взаимодействия для AddNewEmployee.xaml
    /// </summary>
    public partial class AddNewEmployee : Window
    {
        public AddNewEmployee()
        {
            InitializeComponent();
            List<string> allPostsNames = new List<string>();
            List<Posts> posts = StaticResources.db.Posts.ToList();
            foreach (Posts post in posts)
            {
                allPostsNames.Add(post.name_post);
            }
            allPosts.ItemsSource = allPostsNames;
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
        private void SaveEmployee(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || surname.Text == "" || patronumic.Text == "" || username.Text == "" || pass.Text == "" || allPosts.SelectedItem == null)
            {
                MessageBox.Show("Вы ввели не все данные");
            }
            else
            {
                Employees employee = StaticResources.db.Employees.FirstOrDefault(x => x.username == username.Text);
                if (employee == null)
                {
                    Employees newEmployee = new Employees
                    {
                        username = username.Text,
                        password = pass.Text,
                        name = name.Text,
                        surname = surname.Text,
                        patronymic = patronumic.Text,
                        id_post = StaticResources.db.Posts.FirstOrDefault(x => x.name_post == allPosts.Text).id_post,
                    };
                    if (newEmployee.id_post == 1 || newEmployee.id_post == 2) newEmployee.id_role = 1;
                    else newEmployee.id_role = 2;
                    StaticResources.db.Employees.Add(newEmployee);
                    StaticResources.db.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены");
                    this.Hide();
                    MainPageAdmin mainPageAdmin = new MainPageAdmin();
                    mainPageAdmin.Show();
                }
                else
                {
                    MessageBox.Show("Такое имя пользователя уже занято. Задайте другое и повторите попытку");
                }
            }
        }
    }
}
