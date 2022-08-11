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
        public ManagmentMoney(Treasurer t)
        {
            InitializeComponent();
            this.t = t;

            List<Member> members = member.GetAllMembers();

            ManagmentMemberGrid.ItemsSource = members;
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            member = (sender as FrameworkElement).DataContext as Member;

            MessageWindow MW = new MessageWindow(t,member);
            MW.Show();
        }

        //TODO message payer la cotisation, bouton payer la cotisation et créer la page pour payer les driver et prendre l'argent des passagers.

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
