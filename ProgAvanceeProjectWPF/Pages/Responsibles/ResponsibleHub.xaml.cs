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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgAvanceeProjectWPF.Pages.Responsibles
{
    /// <summary>
    /// Interaction logic for ResponsibleHub.xaml
    /// </summary>
    public partial class ResponsibleHub : Page
    {
        Ride ride = new Ride();
        public ResponsibleHub(Responsible r)
        {
            InitializeComponent();

            List<Ride> rides = ride.GetRides(r.Category.Num);
            RidesGrid.ItemsSource = rides;
        }

        private void RideManagmentButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new Uri("../Pages/Responsibles/ManagmentRide.xaml", UriKind.Relative));
        }
    }
}
