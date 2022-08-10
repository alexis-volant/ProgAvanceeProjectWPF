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
        Member m = new Member();
        public ManagmentMoney(Treasurer t)
        {
            InitializeComponent();
            this.t = t;

            ManagmentMemberGrid.ItemsSource = m.GetAllMembers();
        }
        
        //TODO message payer la cotisation, bouton payer la cotisation et créer la page pour payer les driver et prendre l'argent des passagers.

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
