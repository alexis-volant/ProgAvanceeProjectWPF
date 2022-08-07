using ProgAvanceeProjectWPF.Pages.Treasurers.MemberWindows;
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
        Member selectedMember = new Member();

        public ManagmentMember(Treasurer t)
        {
            InitializeComponent();
            this.t = t;
            members = member.GetAllMembers();
            ManagmentMemberGrid.ItemsSource = members;
        }

        private void AddMemberButton(object sender, RoutedEventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.Closed += (ss, ee) =>
            {
                members = member.GetAllMembers();
                ManagmentMemberGrid.ItemsSource = members;
            };
            addMember.Show();
        }

        private void UpdateMember(object sender, RoutedEventArgs e)
        {
            selectedMember = (sender as FrameworkElement).DataContext as Member;

            UpdateMember updateMember = new UpdateMember(selectedMember);
            updateMember.Closed += (ss, ee) =>
            {
                members = selectedMember.GetAllMembers();
                ManagmentMemberGrid.ItemsSource = members;
            };
            updateMember.Show();
        }
        
        private void DeleteMember(object sender, RoutedEventArgs e)
        {
            selectedMember = (sender as FrameworkElement).DataContext as Member;

            DeleteMember deleteMember = new DeleteMember(selectedMember);
            deleteMember.Closed += (ss, ee) =>
            {
                members = selectedMember.GetAllMembers();
                ManagmentMemberGrid.ItemsSource = members;
            };
            deleteMember.Show();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
