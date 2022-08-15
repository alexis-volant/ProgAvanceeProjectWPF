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
        Calender calender = new Calender();
        Responsible r= new Responsible(); 
        Ride ride = new Ride();

        public ResponsibleHub(Responsible r)
        {
            InitializeComponent();
            this.r = r; 

            calender = calender.GetCalender(r.Category);

            var rides = calender.Rides;

            List<RideMore> rideMores = new List<RideMore>();

            foreach (Ride _ride in rides)
            {
                RideMore rideMore = new RideMore(_ride.Num, _ride.PlaceDeparture,
                    _ride.DateDeparture, _ride.PackageFee, _ride.Category,
                    ride.getTotalMemberPlaces(_ride), ride.getTotalBikePlaces(_ride),ride.getRestMemberPlaces(_ride),ride.getRestBikePlaces(_ride));
                rideMores.Add(rideMore);
            }

            RidesGrid.ItemsSource = rideMores;
        }

        private class RideMore
        {
            public int num { get; set; }
            public string placeDeparture { get; set; }
            public DateTime dateDeparture { get; set; }
            public double packageFee { get; set; }
            public Category category { get; set; }
            public int totalMemberPlaces { get; set; }
            public int totalBikesPlaces { get; set; }
            public int totalPlacesLeft { get; set; }
            public int totalBikesLeft { get; set; }

           

            public RideMore(int num, string placeDeparture, DateTime dateDeparture, double packageFee, Category category, int totalMemberPlaces, int totalBikesPlaces,
             int totalPlacesLeft, int totalBikesLeft)
            {
                this.num = num;
                this.placeDeparture = placeDeparture;
                this.dateDeparture = dateDeparture;
                this.packageFee = packageFee;
                this.category = category;
                this.totalMemberPlaces = totalMemberPlaces;
                this.totalBikesLeft = totalBikesLeft;
                this.totalBikesPlaces = totalBikesPlaces;
                this.totalPlacesLeft=totalPlacesLeft;   
            } 
        }

        private void RideManagmentButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;   
            NavigationService.Navigate(new ManagmentRide(calender, r));
        }
    }
}
