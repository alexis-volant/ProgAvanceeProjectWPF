using ProgAvanceeProjectWPF.Pages.Responsibles.Windows;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProgAvanceeProjectWPF.Pages.Responsibles
{
    /// <summary>
    /// Interaction logic for ManagmentRide.xaml
    /// </summary>
    public partial class ManagmentRide : Page
    {
        Responsible r = new Responsible();
        List<Ride> rides = new List<Ride>();
        Ride selectedRide = new Ride();

        public ManagmentRide() { }

        public void RefreshRide(List<Ride> rides)
        {
            ManagmentRideGrid.ItemsSource = rides;
        }

        public ManagmentRide(Responsible r, List<Ride> rides)
        {
            InitializeComponent();
            this.r = r;
            this.rides = rides;

            ManagmentRideGrid.ItemsSource = rides;
        }

        private void AddRideButton(object sender, RoutedEventArgs e)
        {
            AddRide addRide = new AddRide(r);
            addRide.Show();
        }

        private void UpdateRide(object sender, RoutedEventArgs e)
        {
            selectedRide = (sender as FrameworkElement).DataContext as Ride;

            UpdatePlaceDeparture.Text = selectedRide.PlaceDeparture;
            UpdateDateDeparture.Text = selectedRide.DateDeparture.ToString("dd/MM/yyyy");
            UpdatePackageFee.Text = String.Format("{0:0.00}", Convert.ToDouble(selectedRide.PackageFee.ToString()));

            UpdateGrid.Visibility = Visibility.Visible;
            DeleteGrid.Visibility = Visibility.Hidden;
        }
        private void UpdateValidation(object sender, RoutedEventArgs e)
        {
            string UpdatePlace;
            DateTime UpdateDate;
            double UpdateFee;

            if (UpdatePlaceDeparture.Text.Length == 0)
            {
                MessageBox.Show("Le lieu de départ ne peut-être vide.");
                return;
            }
            if (UpdateDateDeparture.Text.Length == 0)
            {
                MessageBox.Show("1) La date de départ ne peut-être vide.\n" +
                    "2) La date s'écrit sous format jj/mm/aaaa.");
                return;
            }

            UpdatePlace = UpdatePlaceDeparture.Text;
            UpdateDate = Convert.ToDateTime(UpdateDateDeparture.Text);
            UpdateFee = UpdatePackageFee.Text.Length == 0 ? 0 : Convert.ToDouble(UpdatePackageFee.Text);

            bool updateStatus = selectedRide.UpdateRide(selectedRide, UpdatePlace, UpdateDate, UpdateFee);

            if (updateStatus)
            {
                rides = selectedRide.GetRides(selectedRide.Category.Num);
                ManagmentRideGrid.ItemsSource = rides;
                UpdateGrid.Visibility = Visibility.Hidden;
                UpdatePlaceDeparture.Text = String.Empty;
                UpdateDateDeparture.Text = String.Empty;
                UpdatePackageFee.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Erreur dans l'encodage de la date, ou du prix.");
            }
        }
        private void UpdateDiscard(object sender, RoutedEventArgs e)
        {
            UpdateGrid.Visibility = Visibility.Hidden;
        }

        private void DeleteRide(object sender, RoutedEventArgs e)
        {
            selectedRide = (sender as FrameworkElement).DataContext as Ride;
            
            UpdateGrid.Visibility = Visibility.Hidden;
            DeleteGrid.Visibility = Visibility.Visible;
        }
        private void DeleteValidation(object sender, RoutedEventArgs e)
        {
            bool deleteStatus = selectedRide.DeleteRide(selectedRide);

            if (deleteStatus)
            {
                rides = selectedRide.GetRides(selectedRide.Category.Num);
                ManagmentRideGrid.ItemsSource = rides;
                DeleteGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Erreur dans la suppression de la balade.");
            }
        }
        private void DeleteDiscard(object sender, RoutedEventArgs e)
        {
            DeleteGrid.Visibility = Visibility.Hidden;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new ResponsibleHub(r));
        }
    }
}
