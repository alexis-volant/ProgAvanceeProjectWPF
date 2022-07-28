using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgAvanceeProjectWPF.Pages.Responsibles
{
    /// <summary>
    /// Interaction logic for ManagmentRide.xaml
    /// </summary>
    public partial class ManagmentRide : Page
    {
        Responsible r = new Responsible();
        List<Ride> rides = new List<Ride>();
        public ManagmentRide(Responsible r, List<Ride> rides)
        {
            InitializeComponent();
            this.r = r;
            this.rides = rides;

            ManagmentRideGrid.ItemsSource = rides;
        }

        private void UpdateRide(object sender, RoutedEventArgs e)
        {
            Ride selectedRide = (sender as FrameworkElement).DataContext as Ride;

            MessageBox.Show(selectedRide.DateDeparture.ToString("MM/dd/yyyy"));
        }

        private void DeleteRide(object sender, RoutedEventArgs e)
        {
            Ride selectedRide = (sender as FrameworkElement).DataContext as Ride;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
