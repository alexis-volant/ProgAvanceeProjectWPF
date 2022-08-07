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
            addRide.Closed += (ss, ee) =>
            {
                rides = selectedRide.GetRides(r.Category.Num);
                ManagmentRideGrid.ItemsSource = rides;
            };
            addRide.Show();
        }

        private void UpdateRide(object sender, RoutedEventArgs e)
        {
            selectedRide = (sender as FrameworkElement).DataContext as Ride;

            UpdateRide updateRide = new UpdateRide(selectedRide);
            updateRide.Closed += (ss, ee) =>
            {
                rides = selectedRide.GetRides(r.Category.Num);
                ManagmentRideGrid.ItemsSource = rides;
            };
            updateRide.Show();
        }

        private void DeleteRide(object sender, RoutedEventArgs e)
        {
            selectedRide = (sender as FrameworkElement).DataContext as Ride;

            DeleteRide deleteRide = new DeleteRide(selectedRide);
            deleteRide.Closed += (ss, ee) =>
            {
                rides = selectedRide.GetRides(r.Category.Num);
                ManagmentRideGrid.ItemsSource = rides;
            };
            deleteRide.Show();
        }
        

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new ResponsibleHub(r));
        }
    }
}
