using ProgAvanceeProjectWPF.Pages.Members.Windows;
using ProgAvanceeProjectWPF.Pages.Members.Windows.Bikes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgAvanceeProjectWPF.Pages.Members
{
    /// <summary>
    /// Interaction logic for MemberRide.xaml
    /// </summary>
    public partial class MemberInscription : Page
    {
        List<Ride> rides = new List<Ride>();
        Ride ride = new Ride();
        Member member = new Member();
        Category category = new Category();
        public MemberInscription(Member m)
        {
            InitializeComponent();

            this.member = m;

            
            CatChoice.ItemsSource = member.Categories;
        }

        private void CatChoice_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
            Category cat = CatChoice.SelectedItem as Category;
           
            List<Ride> rides = ride.GetRidesByCategory(cat.Num);

            if (rides.Any())
            {
                MemberRideGrid.ItemsSource = rides;
            }
            else
            {
                MessageBox.Show("Pas de balades pour cette catégorie");
            }
        }

        private void RideInscription(object sender, RoutedEventArgs e)
        {
            var selectedRide = (sender as FrameworkElement).DataContext as Ride;

            foreach(Inscription insc in member.Inscriptions)
            {
                if (insc.Ride.Num == selectedRide.Num)
                {
                    MessageBox.Show("Vous ête déjà inscrit a cette balade");
                    return;
                }
            }

            if (!member.verifyBalance(selectedRide.PackageFee))
            {
                MessageBox.Show("Vous n'avez pas assez de fond");
                return;
            }

            ChooseBikeForRide bikeChoose = new ChooseBikeForRide(member, selectedRide);
            bikeChoose.Show();
        }

        private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;

            NavigationService.Navigate(new MemberHub(member));

        }
    }
}

