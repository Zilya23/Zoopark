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
    /// Логика взаимодействия для Spisok_Employee_Page.xaml
    /// </summary>
    public partial class Spisok_Employee_Page : Page
    {
        public static ObservableCollection<Employee> employes { get; set;}
        public Spisok_Employee_Page()
        {
            InitializeComponent();
            employes = new ObservableCollection<Employee>(bd_connection.connection.Employee.ToList());

            var e = new Employee();
            this.DataContext = this;
        }

        private void searh_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searh.Text != "")
            {
                empl.SelectedItem = null;
                empl.SelectedItem = new ObservableCollection<Employee>(bd_connection.connection.Employee.Where(z => z.Name.Contains(searh.Text) || z.Surname.Contains(searh.Text) || z.Patronymic.Contains(searh.Text)).ToList());
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as Employee;

            NavigationService.Navigate(new Employee_Info_Page(n));
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
