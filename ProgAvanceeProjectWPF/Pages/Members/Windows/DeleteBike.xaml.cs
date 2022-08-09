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
    /// Interaction logic for DeleteBike.xaml
    /// </summary>
    public partial class DeleteBike : Window
    {
        Bike bike = new Bike();
        public DeleteBike(Bike b)
        {
            InitializeComponent();
            this.bike = b;
        }

        private void DeleteValidation(object sender, RoutedEventArgs e)
        {
            bool deleteStatus = bike.DeleteBike(bike);

            if (deleteStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans la suppression du velo.");
                this.Close();
            }
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
