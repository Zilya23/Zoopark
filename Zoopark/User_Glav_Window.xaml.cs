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
using System.Windows.Shapes;

namespace Zoopark
{
    /// <summary>
    /// Логика взаимодействия для User_Glav_Window.xaml
    /// </summary>
    public partial class User_Glav_Window : Window
    {
        public User_Glav_Window()
        {
            InitializeComponent();
            frame_auto_reg.NavigationService.Navigate(new User_Glav_Page());
        }
    }
}
