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
    /// Логика взаимодействия для AnimalInfoPage.xaml
    /// </summary>
    public partial class AnimalInfoPage : Page
    {
        public static ObservableCollection<Animal> animals { get; set; }

        public static ObservableCollection<Gender> genders { get; set; }
        public static ObservableCollection<Feeding_Ration> feeding_Rations { get; set; }
        public static ObservableCollection<Habitat> habitats { get; set; }
        public static ObservableCollection<Employee> employees { get; set; }

        public static IEnumerable<Gender2> gen { get; set; }
        public static IEnumerable<Feeding2> feed { get; set; }
        public static IEnumerable<Habitats2> hab { get; set; }
        public static IEnumerable<Employe2> empl { get; set; }

        public AnimalInfoPage(Animal n)
        {
            InitializeComponent();

            tb_Name.Text = n.Name;
            tb_BirthDay.Text = (Convert.ToString(n.DateOfBirdth).Split(' '))[0];
            img_Foto.Source = new BitmapImage(new Uri(n.Foto, UriKind.RelativeOrAbsolute));

            animals = new ObservableCollection<Animal>(bd_connection.connection.Animal.ToList());
            genders = new ObservableCollection<Gender>(bd_connection.connection.Gender.ToList());
            feeding_Rations = new ObservableCollection<Feeding_Ration>(bd_connection.connection.Feeding_Ration.ToList());
            habitats = new ObservableCollection<Habitat>(bd_connection.connection.Habitat.ToList());
            employees = new ObservableCollection<Employee>(bd_connection.connection.Employee.ToList());

            gen = from a in animals
                    join g in genders on a.ID_Gender equals g.ID_Gender
                    where n.ID_Animal == a.ID_Animal
                    select new Gender2 { idGender = g.ID_Gender, name = g.Name };

            foreach (var i in gen)
                tb_Sex.Text += i.name;

            feed = from a in animals
                  join f in feeding_Rations on a.ID_FeedingRation equals f.ID_FeedingRation
                  where n.ID_Animal == a.ID_Animal
                  select new Feeding2 { idFeed = f.ID_FeedingRation , name = f.Name };

            foreach (var i in feed)
                tb_Food.Text += i.name;

            hab = from a in animals
                  join h in habitats on a.ID_Habitat equals h.ID_Habitat
                  where n.ID_Animal == a.ID_Animal
                  select new Habitats2 { idHabitat = h.ID_Habitat, name = h.Name };

            foreach (var i in hab)
                tb_Habitat.Text += i.name;

            empl = from a in animals
                  join e in employees on a.ID_Caretaker equals e.ID_Employee
                  where n.ID_Animal == a.ID_Animal
                  select new Employe2 { idEmpl = e.ID_Employee, name = e.Name, surname = e.Surname, patronymic = e.Patronymic};

            foreach (var i in empl)
                tb_Caretaker.Text += (i.surname + " " + i.name + " "  + i.patronymic);

            empl = from a in animals
                   join e in employees on a.ID_Veterinarian equals e.ID_Employee
                   where n.ID_Animal == a.ID_Animal
                   select new Employe2 { idEmpl = e.ID_Employee, name = e.Name, surname = e.Surname, patronymic = e.Patronymic };

            foreach (var i in empl)
                tb_Doctor.Text += (i.surname + " "  + i.name + " "  + i.patronymic);
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

    public class Gender2
    {
        public int idGender { get; set; }
        public string name { get; set; }
    }

    public class Feeding2
    {
        public int idFeed { get; set; }
        public string name { get; set; }
    }

    public class Habitats2
    {
        public int idHabitat { get; set; }
        public string name { get; set; }
    }

    public class Employe2
    {
        public int idEmpl { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
    }
}
