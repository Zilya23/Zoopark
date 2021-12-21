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
    /// Логика взаимодействия для GlavnayaWindow.xaml
    /// </summary>
    public partial class GlavnayaWindow : Window
    {
        public GlavnayaWindow()
        {
            InitializeComponent();
            frame_auto_reg.NavigationService.Navigate(new Advin_Glav_Page());
        }
    }
}
