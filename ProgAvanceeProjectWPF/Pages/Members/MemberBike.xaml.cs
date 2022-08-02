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
        Bike bike = new Bike ();

        Member member = new Member();

        



        public MemberBike(Member m)
        {
            InitializeComponent();

            this.member = m;

            List<Bike> bikes = bike.GetBikesByMember(m);
            BikesGrid.ItemsSource = bikes;


            AddGrid.Visibility = Visibility.Hidden;
            UpdateGrid.Visibility = Visibility.Hidden;

            //System.Diagnostics.Debug.WriteLine($"Resp : {m.Name}");
        }

       
        private void AddBikeBtn(object sender, RoutedEventArgs e)
        {
            
            AddGrid.Visibility = Visibility.Visible;
            UpdateGrid.Visibility = Visibility.Hidden;
                
        }

        private void AddBikeValidation(object sender, RoutedEventArgs e)
        {
            string AddBikeType;
            double AddBikeWeigth;
            double AddBikeLength;

            if (AddType.Equals(""))
            {
                MessageBox.Show("Le type ne peut-être vide.");
                return;
            }
            

            AddBikeType = AddType.Text;
            
            AddBikeWeigth = AddWeigth.Text.Length == 0 ? 0 : Convert.ToDouble(AddWeigth.Text);

            AddBikeLength = AddLength.Text.Length == 0 ? 0 : Convert.ToDouble(AddLength.Text);

            bool addStatus = bike.AddBike(AddBikeType, AddBikeWeigth, AddBikeLength, member);

            if (addStatus)
            {
                List<Bike> bikes = bike.GetBikesByMember(member);
                BikesGrid.ItemsSource = bikes;

                AddGrid.Visibility = Visibility.Hidden;
                AddType.Text = String.Empty;
                AddWeigth.Text = String.Empty;
                AddLength.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Erreur dans l'ajout du velo.");
            }

        }

        //private void confirm
        //{
        //     string msgtext = "Do you want to save Anything In this Document?";
        //        string txt = "My Title";
        //        MessageBoxButton button = MessageBoxButton.YesNoCancel;
        //        MessageBox.Show(msgtext, txt, button);
        //        MessageBoxResult result = MessageBox.Show(msgtext, txt, button);
        //}

        private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
