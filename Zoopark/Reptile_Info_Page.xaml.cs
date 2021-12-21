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
    /// Логика взаимодействия для Reptile_Info_Page.xaml
    /// </summary>
    public partial class Reptile_Info_Page : Page
    {
        public static ObservableCollection<Reptile> reptiles { get; set; }
        public static ObservableCollection<Gender> genders { get; set; }
        public static ObservableCollection<Feeding_Ration> feeding_Rations { get; set; }
        public static ObservableCollection<Habitat> habitats { get; set; }
        public static ObservableCollection<Employee> employees { get; set; }

        public static IEnumerable<Gender2> gend { get; set; }
        public static IEnumerable<Feeding2> feedi { get; set; }
        public static IEnumerable<Habitats2> habi { get; set; }
        public static IEnumerable<Employe2> emplo { get; set; }
        public Reptile_Info_Page(Reptile n)
        {
            InitializeComponent();
            reptiles = new ObservableCollection<Reptile>(bd_connection.connection.Reptile.ToList());
            genders = new ObservableCollection<Gender>(bd_connection.connection.Gender.ToList());
            feeding_Rations = new ObservableCollection<Feeding_Ration>(bd_connection.connection.Feeding_Ration.ToList());
            habitats = new ObservableCollection<Habitat>(bd_connection.connection.Habitat.ToList());
            employees = new ObservableCollection<Employee>(bd_connection.connection.Employee.ToList());

            tb_Name.Text = n.Name;
            tb_BirthDay.Text = (Convert.ToString(n.DateOfBirdth).Split(' '))[0];
            img_Foto.Source = new BitmapImage(new Uri(n.Foto, UriKind.RelativeOrAbsolute));
            tb_Hiber.Text = Convert.ToString(n.HibernationPeriod);
            tb_Temp.Text = Convert.ToString(n.NormalTemperrature);

            gend = from r in reptiles
                  join g in genders on r.ID_Gender equals g.ID_Gender
                  where n.ID_Reptile == r.ID_Reptile
                  select new Gender2 { idGender = g.ID_Gender, name = g.Name };

            foreach (var i in gend)
                tb_Sex.Text += i.name;

            feedi = from r in reptiles
                    join f in feeding_Rations on r.ID_FeedingRation equals f.ID_FeedingRation
                    where n.ID_Reptile == r.ID_Reptile
                    select new Feeding2 { idFeed = f.ID_FeedingRation, name = f.Name };

            foreach (var i in feedi)
                tb_Food.Text += i.name;

            habi = from r in reptiles
                   join h in habitats on r.ID_Habitat equals h.ID_Habitat
                   where n.ID_Reptile == r.ID_Reptile
                   select new Habitats2 { idHabitat = h.ID_Habitat, name = h.Name };

            foreach (var i in habi)
                tb_Habitat.Text += i.name;

            emplo = from r in reptiles
                    join e in employees on r.ID_Caretaker equals e.ID_Employee
                    where n.ID_Reptile == r.ID_Reptile
                    select new Employe2 { idEmpl = e.ID_Employee, name = e.Name, surname = e.Surname, patronymic = e.Patronymic };

            foreach (var i in emplo)
                tb_Caretaker.Text += (i.surname + " " + i.name + " " + i.patronymic);

            emplo = from r in reptiles
                    join e in employees on r.ID_Veterinarian equals e.ID_Employee
                    where n.ID_Reptile == r.ID_Reptile
                    select new Employe2 { idEmpl = e.ID_Employee, name = e.Name, surname = e.Surname, patronymic = e.Patronymic };

            foreach (var i in emplo)
                tb_Doctor.Text += (i.surname + " " + i.name + " " + i.patronymic);
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
