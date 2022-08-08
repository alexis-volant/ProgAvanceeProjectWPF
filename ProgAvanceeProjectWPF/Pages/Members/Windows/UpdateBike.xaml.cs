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

namespace ProgAvanceeProjectWPF.Pages.Members.Windows
{
    /// <summary>
    /// Interaction logic for UpdateBike.xaml
    /// </summary>
    public partial class UpdateBike : Window
    {
        Bike selectedBike = new Bike();
        Member member = new Member();
        public UpdateBike(Member m,Bike b )
        {
            InitializeComponent();
            this.member = m;
            this.selectedBike = b;

            UpdateType.Text = selectedBike.Type;
            UpdateLength.Text = selectedBike.Length.ToString();
            UpdateWeight.Text = selectedBike.Weight.ToString();
        }

        private void UpdateBikeValidation(object sender, RoutedEventArgs e)
        {
            //string UpdatePlace = UpdatePlaceDeparture.Text;
            //DateTime UpdateDate = Convert.ToDateTime(UpdateDateDeparture.Text);
            //double UpdateFee = UpdatePackageFee.Text.Length == 0 ? 0 : Convert.ToDouble(UpdatePackageFee.Text);

            //bool updateStatus = selectedRide.UpdateRide(selectedRide, UpdatePlace, UpdateDate, UpdateFee);

            //if (updateStatus)
            //{
            //    rides = selectedRide.GetRides(selectedRide.Category.Num);
            //    ManagmentRideGrid.ItemsSource = rides;
            //    UpdateGrid.Visibility = Visibility.Hidden;
            //    UpdatePlaceDeparture.Text = String.Empty;
            //    UpdateDateDeparture.Text = String.Empty;
            //    UpdatePackageFee.Text = String.Empty;
            //}
            //else
            //{
            //    MessageBox.Show("Erreur dans l'encodage de la date, ou du prix.");
            //}
        }
    }
}
