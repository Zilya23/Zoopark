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
    /// Логика взаимодействия для Employee_Info_Page.xaml
    /// </summary>
    public partial class Employee_Info_Page : Page
    {
        public static ObservableCollection<Employee> employees { get; set; }
        public static ObservableCollection<Type_Employee> type_Employees { get; set; }
        public static IEnumerable<Type2> types { get; set; }
        public Employee_Info_Page(Employee n)
        {
            InitializeComponent();

            tb_Name.Text = n.Surname + " " + n.Name + " " + n.Patronymic;
            tb_BirthDay.Text = (Convert.ToString(n.DateOfBirdth).Split(' '))[0];
            tb_Tel.Text = n.PhoneNumber;
            img_Foto.Source = new BitmapImage(new Uri(n.Foto, UriKind.RelativeOrAbsolute));
            if (n.MaritalStatus == true)
            {
                tb_Married.Text = "В браке";
            }
            else
            {
                tb_Married.Text = "Не браке";
            }

            employees = new ObservableCollection<Employee>(bd_connection.connection.Employee.ToList());
            type_Employees = new ObservableCollection<Type_Employee>(bd_connection.connection.Type_Employee.ToList());

            types = from e in employees
                               join t in type_Employees on e.ID_TypeEmployee equals t.ID_TypeEmployee
                               where n.ID_Employee == e.ID_Employee
                               select new Type2 { idType = t.ID_TypeEmployee, name = t.Name };

            foreach (var i in types)
                tb_TypeEmpl.Text += i.name;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

    public class Type2
    {
        public int idType { get; set; }
        public string name { get; set; }
    }
}
