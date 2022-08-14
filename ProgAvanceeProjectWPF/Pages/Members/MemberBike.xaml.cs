using ProgAvanceeProjectWPF.Pages.Members.Windows;
using ProgAvanceeProjectWPF.Pages.Members.Windows.Bikes;
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

            BikesGrid.ItemsSource = member.Bikes;

            
            //System.Diagnostics.Debug.WriteLine($"Resp : {m.Name}");
        }


        private void AddBikeBtn(object sender, RoutedEventArgs e)
        {
            AddBike addBike = new AddBike(member);
            addBike.Show();

            addBike.Closed += (ss, ee) =>
            {
                BikesGrid.ItemsSource = null;
                BikesGrid.ItemsSource = member.Bikes;
               
            };
        }
        private void UpdateBikeBtn(object sender, RoutedEventArgs e)
        {
            UpdateBike updateBike = new UpdateBike(member, (sender as FrameworkElement).DataContext as Bike);

            updateBike.Closed += (ss, ee) =>
            {
                BikesGrid.ItemsSource = null;
                BikesGrid.ItemsSource = member.Bikes;
            };

            updateBike.Show();
        }
        private void DeleteBikeBtn(object sender, RoutedEventArgs e)
        {
            DeleteBike deleteBike = new DeleteBike((sender as FrameworkElement).DataContext as Bike);

            deleteBike.Closed += (ss, ee) =>
            {
                BikesGrid.ItemsSource = null;
                BikesGrid.ItemsSource = member.Bikes;
            };

            deleteBike.Show();
        }

    private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;

            NavigationService.Navigate(new MemberHub(member));

        }
    }
}
