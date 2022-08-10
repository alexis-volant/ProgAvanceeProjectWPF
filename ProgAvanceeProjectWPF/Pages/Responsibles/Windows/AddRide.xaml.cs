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
    /// Interaction logic for AddRide.xaml
    /// </summary>
    public partial class AddRide : Window
    {
        Calender calender = new Calender();
        Ride ride = new Ride();

        public AddRide(Calender calender)
        {
            InitializeComponent();
            this.calender = calender;
        }

        private void AddValidation(object sender, RoutedEventArgs e)
        {
            string AddPlace;
            DateTime AddDate;
            double AddFee;
            if (AddPlaceDeparture.Text.Length == 0)
            {
                MessageBox.Show("Le lieu de départ ne peut-être vide.");
                return;
            }
            if (AddDateDeparture.Text.Length == 0)
            {
                MessageBox.Show("1) La date de départ ne peut-être vide.\n" +
                    "2) La date s'écrit sous format jj/mm/aaaa.");
                return;
            }

            AddPlace = AddPlaceDeparture.Text;
            AddDate = Convert.ToDateTime(AddDateDeparture.Text);
            AddFee = AddPackageFee.Text.Length == 0 ? 0 : Convert.ToDouble(AddPackageFee.Text);

            bool addStatus = ride.AddRide(AddPlace, AddDate, AddFee, calender);

            if (addStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'ajout de la balade.");
            }
        }

        private void AddDiscard(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
