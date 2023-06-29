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
    /// Логика взаимодействия для AddNewAppl.xaml
    /// </summary>
    public partial class AddNewAppl : Window
    {
        public AddNewAppl()
        {
            InitializeComponent();
            List<Employees> employees = StaticResources.db.Employees.ToList();
            employees.Remove(StaticResources.User);
            foreach (Employees employee in employees)
            {
                ListBoxEmployees.Items.Add(employee.name + " " + employee.surname);
            }
            List<Clients> clients = StaticResources.db.Clients.ToList();
            foreach (Clients client in clients)
            {
                ListBoxClients.Items.Add(client.name);
            }
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
        private void SaveAppl(object sender, RoutedEventArgs e)
        {
            if (datePicker.Text == "" || datePicker.Text == null || ListBoxClients.SelectedItem == null || ListBoxEmployees.SelectedItem == null || detailsBox.Text == "")
            {
                MessageBox.Show("Вы выбрали не все данные");
            }
            else
            {
                Applications application = new Applications();
                application.id_client = StaticResources.db.Clients.FirstOrDefault(x => x.name == ListBoxClients.SelectedItem.ToString()).id_client;
                string[] FIO = ListBoxEmployees.SelectedItem.ToString().Split(' ');
                string name = FIO[0];
                string surname = FIO[1];
                application.id_employee = StaticResources.db.Employees.FirstOrDefault(x => x.name == name && x.surname == surname).id_employee;
                application.data = DateTime.Parse(datePicker.Text);
                application.details = detailsBox.Text;
                StaticResources.db.Applications.Add(application);
                StaticResources.db.SaveChanges();
                MessageBox.Show("Данные успешно сохранены");
                this.Hide();
                MainPageAdmin mainPageAdmin = new MainPageAdmin();
                mainPageAdmin.Show();
            }
        }
    }
}
