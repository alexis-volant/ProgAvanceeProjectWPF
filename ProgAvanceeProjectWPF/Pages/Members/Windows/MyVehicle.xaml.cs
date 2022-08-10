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
    /// Interaction logic for MyVehicle.xaml
    /// </summary>
    public partial class MyVehicle : Window
    {
        Member member = new Member();
        Vehicle vehicle = new Vehicle();
        List<Vehicle> vehicles = new List<Vehicle>();
        public MyVehicle(Member m)
        {
            InitializeComponent();
            this.member = m;

            //vehicles = vehicle.GetByDriver(member);
            //MyVehicleGrid.ItemsSource = ;
        }

        
    }
}
