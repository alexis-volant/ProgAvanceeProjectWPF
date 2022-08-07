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

namespace ProgAvanceeProjectWPF.Pages.Responsibles.Windows
{
    /// <summary>
    /// Interaction logic for UpdateRide.xaml
    /// </summary>
    public partial class UpdateRide : Window
    {
        Ride ride = new Ride();
        List<Ride> rides = new List<Ride>();
        public UpdateRide(Ride ride)
        {
            InitializeComponent();
            this.ride = ride;

            UpdatePlaceDeparture.Text = ride.PlaceDeparture;
            UpdateDateDeparture.Text = ride.DateDeparture.ToString("dd/MM/yyyy");
            UpdatePackageFee.Text = String.Format("{0:0.00}", Convert.ToDouble(ride.PackageFee.ToString()));
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

            bool updateStatus = ride.UpdateRide(ride, UpdatePlace, UpdateDate, UpdateFee);

            if (updateStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'encodage de la date, ou du prix.");
            }
        }
        private void UpdateDiscard(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
