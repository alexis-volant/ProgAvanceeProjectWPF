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
        public ManagmentMember(Treasurer t)
        {
            InitializeComponent();
            this.t = t;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
