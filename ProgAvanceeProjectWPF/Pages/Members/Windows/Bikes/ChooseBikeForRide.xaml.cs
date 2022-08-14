using ProgAvanceeProjectWPF.Pages.Members.Windows.Inscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ProgAvanceeProjectWPF.Pages.Members.Windows.Bikes
{
    /// <summary>
    /// Interaction logic for ChooseBikeForRide.xaml
    /// </summary>
    public partial class ChooseBikeForRide : Window
    {
        Member member = new Member();
        Ride ride = new Ride(); 
        public ChooseBikeForRide(Member m, Ride r)
        {
            InitializeComponent();
            this.member = m;
            this.ride = r;

            BikesGrid.ItemsSource = member.Bikes.Where(x => x.Type == r.Category.NameCategory);
        }
        private void BikeChooseBtn(object sender, RoutedEventArgs e)
        {
            AddInscription addInscription = new AddInscription(member, ride, (sender as FrameworkElement).DataContext as Bike);
            addInscription.Show();
            this.Close();   
        }
    }
}
