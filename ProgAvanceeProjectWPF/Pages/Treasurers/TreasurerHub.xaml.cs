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
    /// Interaction logic for TreasurerHub.xaml
    /// </summary>
    public partial class TreasurerHub : Page
    {
        Treasurer t = new Treasurer();
        public TreasurerHub(Treasurer t)
        {
            InitializeComponent();
            this.t = t;
        }

        private void MemberManagmentButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new ManagmentMember(t));
        }

        private void ResponsibleManagmentButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new ManagmentResponsible(t));
        }

        private void MoneyManagmentButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.Navigate(new ManagmentMoney(t));
        }
    }
}
