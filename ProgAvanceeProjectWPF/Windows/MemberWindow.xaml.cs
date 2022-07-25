using ProjetWPFAout;
using System;
using System.Windows;

namespace ProgAvanceeProjectWPF.Windows
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        Member m = null;

        public MemberWindow(Member m)
        {
            this.m = m;
            InitializeComponent();
        }

        private void DisconnectButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            mainW.Show();
            this.Close();
        }
    }
}
