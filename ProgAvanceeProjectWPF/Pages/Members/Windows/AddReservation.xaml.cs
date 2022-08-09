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
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Window
    {
        Ride ride = new Ride();
        public AddReservation(Member m, Ride r)
        {
            InitializeComponent();
            this.ride = r; 
            
        }
    }
}
