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
    /// Логика взаимодействия для DelEmployee.xaml
    /// </summary>
    public partial class DelEmployee : Window
    {
        public DelEmployee()
        {
            InitializeComponent();
            List<Employees> employees = StaticResources.db.Employees.ToList();
            employees.Remove(StaticResources.User);
            allEmployees.ItemsSource = employees;
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
        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Tag);
            Employees employee = StaticResources.db.Employees.FirstOrDefault(x => x.id_employee == id);
            if (employee != null)
            {
                StaticResources.db.Employees.Remove(employee);
                StaticResources.db.SaveChanges();
                MessageBox.Show("Сотрудник успешно удален!");
                this.Hide();
                MainPageAdmin mainPageAdmin = new MainPageAdmin();
                mainPageAdmin.Show();
            }
            else MessageBox.Show("Произошла ошибка");
        }
    }
}
