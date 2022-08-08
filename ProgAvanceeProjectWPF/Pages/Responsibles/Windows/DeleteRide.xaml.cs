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
    /// Interaction logic for DeleteRide.xaml
    /// </summary>
    public partial class DeleteRide : Window
    {
        Ride r = new Ride();
        public DeleteRide(Ride r)
        {
            InitializeComponent();
            this.r = r;
        }

        private void DeleteValidation(object sender, RoutedEventArgs e)
        {
            bool deleteStatus = r.DeleteRide(r);

            if (deleteStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans la suppression de la balade.");
            }
        }

        private void DeleteDiscard(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
