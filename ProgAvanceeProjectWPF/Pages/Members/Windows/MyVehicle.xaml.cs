using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgAvanceeProjectWPF.Pages.Members.Windows
{
    /// <summary>
    /// Interaction logic for MyVehicle.xaml
    /// </summary>
    public partial class MyVehicle : Window
    {
        Member member = new Member();
        
        public MyVehicle(Member m)
        {
            InitializeComponent();
            this.member = m;
            MyVehicleGrid.ItemsSource = member.Vehicles;
        }

        public void AddCoVehicule(object sender, RoutedEventArgs e)
        {

        }

        public void VehiculeChoice(object sender, RoutedEventArgs e)
        {

        }



    }
}
