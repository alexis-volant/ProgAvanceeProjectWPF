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

namespace ProgAvanceeProjectWPF.Pages.Members
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    /// 
 
    public partial class MemberHub : Page
    {
        Member m = new Member();

        Ride ride = new Ride();
        public MemberHub(Member m)
        {
            InitializeComponent();
            this.m = m;
            List<Ride> rides = ride.GetRidesByMember(m);
            RidesGrid.ItemsSource = rides;
        }
                
        private void GoToMemberBikePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new MemberBike(m));
        }
        private void GoToMemberRidePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new MemberRide(m));
        }
   
    }
}
