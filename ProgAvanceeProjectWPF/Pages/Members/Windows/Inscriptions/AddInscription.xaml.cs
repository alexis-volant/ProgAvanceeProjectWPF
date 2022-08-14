using ProgAvanceeProjectWPF.Pages.Members.Windows.Vehicles;
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

namespace ProgAvanceeProjectWPF.Pages.Members.Windows.Inscriptions
{
    /// <summary>
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddInscription: Window
    {
        Ride ride = new Ride();
        Member member = new Member();
        Vehicle vehicle = new Vehicle();
        Inscription inscription = new Inscription();
        Bike bike = new Bike();
        Message message = new Message();
        public AddInscription(Member m, Ride r, Bike b)
        {
            InitializeComponent();
            this.ride = r;
            this.member = m;
            this.bike = b;

            foreach(Vehicle vehicle in ride.Vehicles)
            {
                var placesLeft = PlacesLeft(vehicle);
                vehicle.NbrPlacesMembers = placesLeft.Item1;
                vehicle.NbrPlacesBikes = placesLeft.Item2;
            }
            VehicleGrid.ItemsSource = ride.Vehicles;
        }

        public (int,int) PlacesLeft(Vehicle vehicle)
        {
            int passagerLeft = vehicle.CalculPassengersLeft(vehicle);
            int bikeLeft = vehicle.CalculBikeLeft(vehicle);

            return(passagerLeft, bikeLeft);
        }

        public void VehicleChoice(object sender, RoutedEventArgs e)
        {
            Vehicle ChoosenVehicule = (sender as FrameworkElement).DataContext as Vehicle;

            if (ChoosenVehicule.NbrPlacesMembers <= 0)
            {
                MessageBox.Show("Plus de place passagers dans le vehicule");
                return;
            }
            if (ChoosenVehicule.NbrPlacesBikes <= 0)
            {
                MessageBox.Show("Plus de place velos dans le vehicule");
                return;
            }

            bool addStatus = inscription.AddInscription(member, ride, bike, true, true, ChoosenVehicule);

            if (addStatus)
            {
                double amount = ride.PackageFee;
                Member driver = ChoosenVehicule.Driver;
                string obj = "Inscription balade";
                string content = $"Le membre {string.Concat(member.Name + " " + member.FirstName)} doit {ride.PackageFee}€ au conducteur {string.Concat(driver.Name + " " + driver.FirstName)}";
                message.AddMessage(obj, content);

                member.calculBalance(-amount);

                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'inscription.");
                this.Close();
            }
  
        }

        public void MyVehicle(object sender, RoutedEventArgs e)
        {
            this.Close();
            MyVehicle myVehicle = new MyVehicle(member, ride, bike);
            myVehicle.Show();
        }
    }
}
