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
    /// Логика взаимодействия для EmplyeeTypePage.xaml
    /// </summary>
    public partial class EmplyeeTypePage : Page
    {
        public EmplyeeTypePage()
        {
            InitializeComponent();
        }

        private void btn_admin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin_auto_Page());
        }

        private void btn_user_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new User_auto_Page());
        }
    }
}
