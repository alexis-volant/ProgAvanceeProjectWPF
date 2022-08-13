using ProgAvanceeProjectWPF.Pages.Treasurers.MoneyWindows;
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
    /// Interaction logic for ManagmentMoney.xaml
    /// </summary>
    public partial class ManagmentMoney : Page
    {
        Treasurer t = new Treasurer();
        Member member = new Member();
        List<Member> members = new List<Member>();
        public ManagmentMoney(Treasurer t)
        {
            InitializeComponent();
            this.t = t;

            members = member.CheckDate(member.GetAllMembers());

            ManagmentMemberGrid.ItemsSource = members;
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            member = (sender as FrameworkElement).DataContext as Member;
            MessageWindow MW = new MessageWindow(member, t);
            MW.Show();
        }

        private void PayFee(object sender, RoutedEventArgs e)
        {
            member = (sender as FrameworkElement).DataContext as Member;
            PayFeeWindow PFW = new PayFeeWindow(member);
            RefreshGrid(PFW);
        }

        private void AddMoney(object sender, RoutedEventArgs e)
        {
            member = (sender as FrameworkElement).DataContext as Member;
            AddMoneyWindow AMW = new AddMoneyWindow(member);
            RefreshGrid(AMW);
        }

        //TODO Créer la page pour payer les driver et prendre l'argent des passagers.

        public void RefreshGrid(Window win)
        {
            win.Closed += (ss, ee) =>
            {
                members = member.GetAllMembers();
                ManagmentMemberGrid.ItemsSource = members;
            };
            win.Show();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
