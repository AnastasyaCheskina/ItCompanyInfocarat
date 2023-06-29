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
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Window
    {
        public PersonalAccount()
        {
            InitializeComponent();
            name.Text = StaticResources.User.name;
            surname.Text = StaticResources.User.surname;
            patronumic.Text = StaticResources.User.patronymic;
            username.Text = StaticResources.User.username;
            pass.Text = StaticResources.User.password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            if (StaticResources.User.id_role == 1)
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
        private void ButtonEditData(object sender, RoutedEventArgs e)
        {
            btnEdit.IsEnabled = false;
            btnSave.IsEnabled = true;
            name.IsReadOnly = false;
            surname.IsReadOnly = false;
            patronumic.IsReadOnly = false;
            username.IsReadOnly = false;
            pass.IsReadOnly = false;
        }
        private void ButtonSaveChanges(object sender, RoutedEventArgs e)
        {
            btnEdit.IsEnabled = true;
            btnSave.IsEnabled = false;
            name.IsReadOnly = true;
            surname.IsReadOnly = true;
            patronumic.IsReadOnly = true;
            username.IsReadOnly = true;
            pass.IsReadOnly = true;
            var userForUpdate = StaticResources.db.Employees.FirstOrDefault(x => x.id_employee == StaticResources.User.id_employee);
            userForUpdate.name = name.Text;
            userForUpdate.surname = surname.Text;
            userForUpdate.patronymic = patronumic.Text;
            userForUpdate.username = username.Text;
            userForUpdate.password = pass.Text;
            StaticResources.db.SaveChanges();
            StaticResources.User = userForUpdate;
            MessageBox.Show("Данные успешно сохранены!");
        }
        private void ButtonLogOut(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
