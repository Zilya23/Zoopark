﻿using System;
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
    /// Логика взаимодействия для Add_Reptile_Page.xaml
    /// </summary>
    public partial class Add_Reptile_Page : Page
    {
        public Add_Reptile_Page()
        {
            InitializeComponent();
        }

        private void Btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Btn_registration_Click(object sender, RoutedEventArgs e)
        {
            var a = new Reptile();
            a.Name = name_txt.Text;
            a.ID_Gender = Convert.ToInt32(sex_txt.Text);
            a.DateOfBirdth = Convert.ToDateTime(date_txt.Text);
            a.ID_FeedingRation = Convert.ToInt32(feed_txt.Text);
            a.ID_Habitat = Convert.ToInt32(habitat_txt.Text);
            a.NormalTemperrature = Convert.ToInt32(temp_txt.Text);
            a.HibernationPeriod = Convert.ToInt32(sleep_txt.Text);
            a.ID_Caretaker = Convert.ToInt32(care_txt.Text);
            a.ID_Veterinarian = Convert.ToInt32(vet_txt.Text);
            bd_connection.connection.Reptile.Add(a);
            bd_connection.connection.SaveChanges();
            MessageBox.Show("All OK");
            NavigationService.GoBack();
        }
    }
}
