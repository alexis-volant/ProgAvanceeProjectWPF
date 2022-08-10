using ProgAvanceeProjectWPF.Pages.Members.Windows;
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

            List<string> CatNamelist = new List<string>(); 
            foreach (Category c in member.Categories)
            {
                CatNamelist.Add(c.NameCategory);
            }
            CatChoice.ItemsSource = CatNamelist;
        }

        private void CatChoice_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
            int idCategory = CatChoice.SelectedIndex;
            idCategory++;

            //if (!String.IsNullOrEmpty(textBoxRide.Text))
            //{
            //    textBoxRide.Clear();
            //}

            List<Ride> rides = ride.GetRidesByCategory(idCategory);

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
                if (insc.Ride.Equals(selectedRide))
                {
                    MessageBox.Show("Vous ête déjà inscrit a cette balade");
                    break;
                }
            }

            //AddInscription addInscription = new AddInscription(member, selectedRide);

            //addInscription.Closed += (ss, ee) =>
            //{
            //   //refresh
            //};

            //addInscription.Show();

            ChooseBikeForRide bikeChoose = new ChooseBikeForRide(member, selectedRide);

            bikeChoose.Closed += (ss, ee) =>
            {
                //refresh
            };

            bikeChoose.Show();
        }

        private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;

            NavigationService.Navigate(new MemberHub(member));

        }
    }
}

