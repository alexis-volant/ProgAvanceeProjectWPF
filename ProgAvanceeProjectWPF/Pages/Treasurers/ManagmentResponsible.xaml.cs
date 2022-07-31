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
    /// Interaction logic for ManagmentResponsible.xaml
    /// </summary>
    public partial class ManagmentResponsible : Page
    {
        Treasurer t = new Treasurer();
        public ManagmentResponsible(Treasurer t)
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
