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
        Ride selectedRide = new Ride();

        public ManagmentRide(Responsible r, List<Ride> rides)
        {
            InitializeComponent();
            this.r = r;
            this.rides = rides;

            AddGrid.Visibility = Visibility.Hidden;
            UpdateGrid.Visibility = Visibility.Hidden;
            DeleteGrid.Visibility = Visibility.Hidden;

            ManagmentRideGrid.ItemsSource = rides;
        }

        private void AddRideButton(object sender, RoutedEventArgs e)
        {
            AddGrid.Visibility = Visibility.Visible;
            UpdateGrid.Visibility = Visibility.Hidden;
            DeleteGrid.Visibility = Visibility.Hidden;
        }

        private void AddValidation(object sender, RoutedEventArgs e)
        {
            string AddPlace;
            DateTime AddDate;
            if(AddPlaceDeparture.Text.Length > 0)
            {
                AddPlace = AddPlaceDeparture.Text;
                if (AddDateDeparture.Text.Length > 0)
                {
                    AddDate = Convert.ToDateTime(AddDateDeparture.Text);

                    double AddFee = AddPackageFee.Text.Length == 0 ? 0 : Convert.ToDouble(AddPackageFee.Text);

                    bool addStatus = selectedRide.AddRide(AddPlace, AddDate, AddFee, r.Category);

                    if (addStatus)
                    {
                        rides = selectedRide.GetRides(r.Category.Num);
                        ManagmentRideGrid.ItemsSource = rides;
                        AddGrid.Visibility = Visibility.Hidden;
                        AddPlaceDeparture.Text = String.Empty;
                        AddDateDeparture.Text = String.Empty;
                        AddPackageFee.Text = String.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Erreur dans l'ajout de la balade.");
                    }
                }
                else
                {
                    MessageBox.Show("1) La date de départ ne peut-être vide.\n" +
                        "2) La date s'écrit sous format jj/mm/aaaa.");
                }
            }
            else
            {
                MessageBox.Show("Le lieu de départ ne peut-être vide.");
            }
        }

        private void AddDiscard(object sender, RoutedEventArgs e)
        {
            AddGrid.Visibility = Visibility.Hidden;
        }

        private void UpdateRide(object sender, RoutedEventArgs e)
        {
            selectedRide = (sender as FrameworkElement).DataContext as Ride;

            UpdatePlaceDeparture.Text = selectedRide.PlaceDeparture;
            UpdateDateDeparture.Text = selectedRide.DateDeparture.ToString("dd/MM/yyyy");
            UpdatePackageFee.Text = selectedRide.PackageFee.ToString();

            AddGrid.Visibility = Visibility.Hidden;
            UpdateGrid.Visibility = Visibility.Visible;
            DeleteGrid.Visibility = Visibility.Hidden;
        }

        private void UpdateValidation(object sender, RoutedEventArgs e)
        {
            string UpdatePlace = UpdatePlaceDeparture.Text;
            DateTime UpdateDate = Convert.ToDateTime(UpdateDateDeparture.Text);
            double UpdateFee = Convert.ToDouble(UpdatePackageFee.Text);

            bool updateStatus = selectedRide.UpdateRide(selectedRide, UpdatePlace, UpdateDate, UpdateFee);

            if (updateStatus)
            {
                rides = selectedRide.GetRides(selectedRide.Category.Num);
                ManagmentRideGrid.ItemsSource = rides;
                UpdateGrid.Visibility = Visibility.Hidden;
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
            
            AddGrid.Visibility = Visibility.Hidden;
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
