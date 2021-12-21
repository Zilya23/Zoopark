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
    /// Логика взаимодействия для Bird_InfoPage.xaml
    /// </summary>
    public partial class Bird_InfoPage : Page
    {
        public static ObservableCollection<Bird> birds { get; set; }
        public static ObservableCollection<Gender> genders { get; set; }
        public static ObservableCollection<Feeding_Ration> feeding_Rations { get; set; }
        public static ObservableCollection<Habitat> habitats { get; set; }
        public static ObservableCollection<Employee> employees { get; set; }
        public static ObservableCollection<Wintering_Place> wintering_places { get; set; }

        public static IEnumerable<Gender2> gend { get; set; }
        public static IEnumerable<Feeding2> feedi { get; set; }
        public static IEnumerable<Habitats2> habi { get; set; }
        public static IEnumerable<Employe2> emplo { get; set; }
        public static IEnumerable<Wintering2> winter { get; set; }
        public Bird_InfoPage( Bird n)
        {
            InitializeComponent();
            birds = new ObservableCollection<Bird>(bd_connection.connection.Bird.ToList());
            genders = new ObservableCollection<Gender>(bd_connection.connection.Gender.ToList());
            feeding_Rations = new ObservableCollection<Feeding_Ration>(bd_connection.connection.Feeding_Ration.ToList());
            habitats = new ObservableCollection<Habitat>(bd_connection.connection.Habitat.ToList());
            employees = new ObservableCollection<Employee>(bd_connection.connection.Employee.ToList());
            wintering_places = new ObservableCollection<Wintering_Place>(bd_connection.connection.Wintering_Place.ToList());

            tb_Name.Text = n.Name;
            tb_BirthDay.Text = (Convert.ToString(n.DateOfBirdth).Split(' '))[0];
            img_Foto.Source = new BitmapImage(new Uri(n.Foto, UriKind.RelativeOrAbsolute));

            gend = from b in birds
                  join g in genders on b.ID_Gender equals g.ID_Gender
                  where n.ID_Bird == b.ID_Bird
                  select new Gender2 { idGender = g.ID_Gender, name = g.Name };

            foreach (var i in gend)
                tb_Sex.Text += i.name;

            feedi = from b in birds
                    join f in feeding_Rations on b.ID_FeedingRation equals f.ID_FeedingRation
                    where n.ID_Bird == b.ID_Bird
                    select new Feeding2 { idFeed = f.ID_FeedingRation, name = f.Name };

            foreach (var i in feedi)
                tb_Food.Text += i.name;

            habi = from b in birds
                  join h in habitats on b.ID_Habitat equals h.ID_Habitat
                  where n.ID_Bird == b.ID_Bird
                  select new Habitats2 { idHabitat = h.ID_Habitat, name = h.Name };

            foreach (var i in habi)
                tb_Habitat.Text += i.name;

            winter = from b in birds
                   join w in wintering_places on b.ID_WinteringPlace equals w.ID_WinteringPlace
                   where n.ID_Bird == b.ID_Bird
                   select new Wintering2 { idWintering = w.ID_WinteringPlace, name = w.NameCountry };

            foreach (var i in winter)
                tb_Wintering.Text += i.name;

            emplo = from b in birds
                   join e in employees on b.ID_Caretaker equals e.ID_Employee
                   where n.ID_Bird == b.ID_Bird
                   select new Employe2 { idEmpl = e.ID_Employee, name = e.Name, surname = e.Surname, patronymic = e.Patronymic };

            foreach (var i in emplo)
                tb_Caretaker.Text += (i.surname + " " + i.name + " " + i.patronymic);

            emplo = from b in birds
                   join e in employees on b.ID_Veterinarian equals e.ID_Employee
                   where n.ID_Bird == b.ID_Bird
                   select new Employe2 { idEmpl = e.ID_Employee, name = e.Name, surname = e.Surname, patronymic = e.Patronymic };

            foreach (var i in emplo)
                tb_Doctor.Text += (i.surname + " " + i.name + " " + i.patronymic);
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

    public class Wintering2
    {
        public int idWintering { get; set; }
        public string name { get; set; }
    }
}
