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
        Calender calender = new Calender();
        Responsible r = new Responsible();  
        Ride ride = new Ride();

        public ManagmentRide(Calender calender, Responsible r)
        {
            InitializeComponent();
            this.calender = calender;
            this.r = r;
            ManagmentRideGrid.ItemsSource = calender.Rides;
        }

        //TODO Utiliser Classe CALENDER Bisous
        //TODO Utiliser Classe CALENDER Bisous

        private void AddRideButton(object sender, RoutedEventArgs e)
        {
            AddRide addRide = new AddRide(calender);
            RefreshGrid(addRide);
        }
        private void UpdateRide(object sender, RoutedEventArgs e)
        {
            ride = (sender as FrameworkElement).DataContext as Ride;
            UpdateRide updateRide = new UpdateRide(calender, ride);
            RefreshGrid(updateRide);
        }
        private void DeleteRide(object sender, RoutedEventArgs e)
        {
            ride = (sender as FrameworkElement).DataContext as Ride;
            DeleteRide deleteRide = new DeleteRide(calender, ride);
            RefreshGrid(deleteRide);
        }
        public void RefreshGrid(Window win)
        {
            win.Closed += (ss, ee) =>
            {
                ManagmentRideGrid.ItemsSource = null;
                ManagmentRideGrid.ItemsSource = calender.Rides;
            };
            win.Show();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new ResponsibleHub(r));
        }
    }
}
