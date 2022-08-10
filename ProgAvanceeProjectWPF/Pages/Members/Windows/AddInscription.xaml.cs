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
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddInscription: Window
    {
        Ride ride = new Ride();
        Member member = new Member();
        public AddInscription(Member m, Ride r)
        {
            InitializeComponent();
            this.ride = r;
            this.member = m;    

            VehicleGrid.ItemsSource = ride.Vehicles;
        }

        public void VehicleChoice(object sender, RoutedEventArgs e)
        {

        }

        public void AddCoVehicle(object sender, RoutedEventArgs e)
        {
            this.Close();
            MyVehicle myVehicle = new MyVehicle(member);
            myVehicle.Show();
        }
    }
}
