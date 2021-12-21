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
using System.Collections.ObjectModel;

namespace Zoopark
{
    /// <summary>
    /// Логика взаимодействия для User_auto_Page.xaml
    /// </summary>
    public partial class User_auto_Page : Page
    {
        public static ObservableCollection<Employee> employee { get; set; }
        public User_auto_Page()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employee = new ObservableCollection<Employee>(bd_connection.connection.Employee.ToList());
            int log = Convert.ToInt32(txt_login.Text);
            int pass = Convert.ToInt32(txt_password.Password);
            var z = employee.Where(a => a.ID_Employee == log && a.Password == pass).FirstOrDefault();
            if (z != null)
            {
                User_Glav_Window glavn = new User_Glav_Window();
                glavn.Show();
                App.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Логин или пароль неверный", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
