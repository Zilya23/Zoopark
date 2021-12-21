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
    /// Логика взаимодействия для BirdPage.xaml
    /// </summary>
    public partial class BirdPage : Page
    {
        public static ObservableCollection<Bird> birds { get; set; }
        public BirdPage()
        {
            InitializeComponent();
            birds = new ObservableCollection<Bird>(bd_connection.connection.Bird.ToList());

            var e = new Bird();
            this.DataContext = this;
        }

        private void searh_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_searh.Text != "")
            {
                bird.SelectedItem = null;
                bird.SelectedItem = new ObservableCollection<Bird>(bd_connection.connection.Bird.Where(z => z.Name.Contains(txt_searh.Text)).ToList());
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as Bird;

            NavigationService.Navigate(new Bird_InfoPage(n));
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Bird_Page());
        }
    }
}
