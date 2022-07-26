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

namespace ProgAvanceeProjectWPF.Pages.Member
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    /// 
 
    public partial class MemberHub : Page
    {
        public MemberHub()
        {
            InitializeComponent();
        }
                
        private void GoToBikeBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new Uri("../Pages/Member/MemberBike.xaml", UriKind.Relative));
        }
    }
}
