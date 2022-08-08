using ProgAvanceeProjectWPF.Pages.Treasurers;
using ProjetWPFAout;
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
using System.Windows.Shapes;

namespace ProgAvanceeProjectWPF.Windows
{
    /// <summary>
    /// Interaction logic for TreasurerWindow.xaml
    /// </summary>
    public partial class TreasurerWindow : Window
    {
        Treasurer t = new Treasurer();
        public TreasurerWindow(Treasurer t)
        {
            this.t = t;
            InitializeComponent();
            Main.Content = null;
            Main.Content = new TreasurerHub(t);
            FirstName.Content = t.FirstName;
        }

        private void DisconnectButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            mainW.Show();
            this.Close();
        }
    }
}
