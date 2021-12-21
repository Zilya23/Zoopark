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
    /// Логика взаимодействия для ReptailPage.xaml
    /// </summary>
    public partial class ReptailPage : Page
    {
        public static ObservableCollection<Reptile> reptiles { get; set; }
        public ReptailPage()
        {
            InitializeComponent();

            reptiles = new ObservableCollection<Reptile>(bd_connection.connection.Reptile.ToList());

            var e = new Reptile();
            this.DataContext = this;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as Reptile;
            NavigationService.Navigate(new Reptile_Info_Page(n));
        }

        private void searh_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searh.Text != "")
            {
                reptile.SelectedItem = null;
                reptile.SelectedItem = new ObservableCollection<Reptile>(bd_connection.connection.Reptile.Where(z => z.Name.Contains(searh.Text)).ToList());
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Reptile_Page());
        }
    }
}
