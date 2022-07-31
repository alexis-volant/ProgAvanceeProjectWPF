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

namespace ProgAvanceeProjectWPF.Pages.Treasurers
{
    /// <summary>
    /// Interaction logic for ManagmentMember.xaml
    /// </summary>
    public partial class ManagmentMember : Page
    {
        Treasurer t = new Treasurer();
        Member member = new Member();
        List<Member> members = new List<Member>();
        public ManagmentMember(Treasurer t)
        {
            InitializeComponent();
            this.t = t;
            members = member.GetAllMembers();
            ManagmentMemberGrid.ItemsSource = members;
            /*members = member.GetAllMembers();
            RidesGrid.ItemsSource = rides;*/
        }

        private void UpdateMember(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteMember(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
