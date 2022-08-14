using ProgAvanceeProjectWPF.Pages.Members.Windows;
using ProgAvanceeProjectWPF.Pages.Members.Windows.Categories;
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
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    /// 
 
    public partial class MemberHub : Page
    {
        Member member = new Member();

        Ride ride = new Ride();
        public MemberHub(Member m)
        {
            InitializeComponent();
            this.member = m;

            LblFirstName.Content = string.Concat(member.Name," ",member.FirstName);
            LblBalance.Content = member.Balance;

            List<Ride> rides = new List<Ride>();
            foreach (Inscription insc in member.Inscriptions)
            {
                rides.Add(insc.Ride);
            }
            RidesGrid.ItemsSource = rides.OrderBy(x => x.Num);



            BikesGrid.ItemsSource = member.Bikes;

            AddListCatContent(); 
        }

        private void AddListCatContent()
        {
            ListView listViewCat = new ListView();
            if (member.Categories.Any())
            {
                foreach (Category cat in member.Categories)
                {
                    listViewCat.Items.Add(cat.NameCategory);
                }

                ListCat.Children.Add(listViewCat);
            }
            else
            {
                listViewCat.Items.Add("Pas de catégories");
                ListCat.Children.Add(listViewCat);
            }
        }

        private void AddCategory(object sender, RoutedEventArgs e)
        {
            AddCategory addCategory = new AddCategory(member);
            addCategory.Show();

            addCategory.Closed += (ss, ee) =>
            {
               ListCat.Children.Clear ();
               AddListCatContent();

               LblBalance.Content = string.Empty;
               LblBalance.Content = member.Balance;

            };
        }

        private void GoToMemberBikePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new MemberBike(member));
            
        }
        private void GoToMemberInscriptionPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new MemberInscription(member));    
        }
   
    }
}
