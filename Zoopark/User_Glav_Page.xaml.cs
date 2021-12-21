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
    /// Логика взаимодействия для User_Glav_Page.xaml
    /// </summary>
    public partial class User_Glav_Page : Page
    {
        public User_Glav_Page()
        {
            InitializeComponent();
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
