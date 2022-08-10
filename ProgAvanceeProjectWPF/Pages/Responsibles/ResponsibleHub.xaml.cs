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
        Responsible r = new Responsible();  

        public ResponsibleHub(Responsible r)
        {
            InitializeComponent();
            this.r = r;
            calender = calender.GetCalender(r.Category);
            RidesGrid.ItemsSource = calender.Rides;
        }

        private void RideManagmentButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;   
            NavigationService.Navigate(new ManagmentRide(calender, r));
        }
    }
}
