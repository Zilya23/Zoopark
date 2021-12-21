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

namespace Zoopark
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void Btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Btn_registration_Click(object sender, RoutedEventArgs e)
        {
            var a = new Employee();
            a.Name = name_txt.Text;
            a.Surname = login_txt.Text;
            a.Patronymic = patronymic_txt.Text;
            a.DateOfBirdth = Convert.ToDateTime(date_txt.Text);
            a.PhoneNumber = phone_txt.Text;
            a.MaritalStatus = box_marry.IsChecked;
            a.ID_TypeEmployee = Convert.ToInt32(type_txt.Text);
            a.Password = Convert.ToInt32(password_txt.Text);
            bd_connection.connection.Employee.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("All OK");
            NavigationService.GoBack();
        }
    }
}
