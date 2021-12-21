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
    /// Логика взаимодействия для Advin_Glav_Page.xaml
    /// </summary>
    public partial class Advin_Glav_Page : Page
    {
        public Advin_Glav_Page()
        {
            InitializeComponent();
        }

        private void btn_employee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Spisok_Employee_Page());
        }

        private void btn_animal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalPage());
        }

        private void btn_bird_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BirdPage());
        }

        private void btn_reptile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReptailPage());
        }
    }
}
