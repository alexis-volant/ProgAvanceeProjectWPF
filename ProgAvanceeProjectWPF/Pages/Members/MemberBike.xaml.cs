using ProgAvanceeProjectWPF.Pages.Members.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgAvanceeProjectWPF.Pages.Members
{
    /// <summary>
    /// Logique d'interaction pour MemberBike.xaml
    /// </summary>
    public partial class MemberBike : Page
    {
        Bike bike = new Bike();

        Member member = new Member();

        Category category = new Category();



        public MemberBike(Member m)
        {
            InitializeComponent();

            this.member = m;

            List<Bike> bikes = bike.GetBikesByMember(m);
            BikesGrid.ItemsSource = bikes;

            
            //System.Diagnostics.Debug.WriteLine($"Resp : {m.Name}");
        }


        private void AddBikeBtn(object sender, RoutedEventArgs e)
        {
            AddBike addBike = new AddBike(member);

            addBike.Closed += (ss, ee) =>
            {
                List<Bike> bikes = bike.GetBikesByMember(member);
                BikesGrid.ItemsSource = bikes;
            };

            addBike.Show();
        }

        

       

    private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
