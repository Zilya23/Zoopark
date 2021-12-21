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
    /// Логика взаимодействия для AnimalPage.xaml
    /// </summary>
    public partial class AnimalPage : Page
    {
        public static ObservableCollection<Animal> animals { get; set; }
        public AnimalPage()
        {
            InitializeComponent();
            animals = new ObservableCollection<Animal>(bd_connection.connection.Animal.ToList());

            var e = new Animal();
            this.DataContext = this;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void searh_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searh.Text != "")
            {
                animal.SelectedItem = null;
                animal.SelectedItem = new ObservableCollection<Animal>(bd_connection.connection.Animal.Where(z => z.Name.Contains(searh.Text)).ToList());
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as Animal;

            NavigationService.Navigate(new AnimalInfoPage(n));
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Animal_Page());
        }
    }
}
