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

namespace ProgAvanceeProjectWPF.Pages.Members.Windows.Vehicles
{
    /// <summary>
    /// Interaction logic for MyVehicle.xaml
    /// </summary>
    public partial class MyVehicle : Window
    {
        Member member = new Member();
        Vehicle vehicle = new Vehicle();
        Bike bike = new Bike();
        Inscription inscription = new Inscription();
        Ride ride = new Ride();
        public MyVehicle(Member m, Ride r, Bike b)
        {
            InitializeComponent();
            this.member = m;
            this.ride = r;
            this.bike = b;
            MyVehicleGrid.ItemsSource = member.Vehicles;
        }

        private void AddVehiculeValidation(object sender, RoutedEventArgs e)
        {
            int PassengerPlace;
            int BikePlace;

            
            if (!int.TryParse(AddPassengerPlace.Text, out PassengerPlace))
            {
                MessageBox.Show("Veuillez encoder un nombre correct");
                return;
            }
            
            if (!int.TryParse(AddBikePlace.Text, out BikePlace))
            {
                MessageBox.Show("Veuillez encoder un nombre correct");
                return;
            }


            bool addStatus = vehicle.CreateVehicle(member, PassengerPlace, BikePlace);

            if (addStatus)
            {
               MyVehicleGrid.ItemsSource = null;
               MyVehicleGrid.ItemsSource = member.Vehicles;
               MessageBox.Show("Ajout véhicule réussi");
            }
            else
            {
                MessageBox.Show("Erreur dans l'ajout du vehicule.");
                return;
            }
        }

        public void VehiculeChoice(object sender, RoutedEventArgs e)
        {
            Vehicle ChoosenVehicule = (sender as FrameworkElement).DataContext as Vehicle;

            bool addStatus = inscription.AddInscription(member, ride, bike, false, false, ChoosenVehicule);

            if (addStatus)
            {
                MessageBox.Show("Inscription à la balade réussie");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'inscription.");
                this.Close();
            }
        }



    }
}
