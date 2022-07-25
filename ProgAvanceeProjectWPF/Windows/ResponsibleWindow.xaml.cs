﻿using ProjetWPFAout;
using System.Windows;

namespace ProgAvanceeProjectWPF.Windows
{
    /// <summary>
    /// Interaction logic for ResponsibleWindow.xaml
    /// </summary>
    public partial class ResponsibleWindow : Window
    {
        Responsible r = null;
        public ResponsibleWindow(Responsible r)
        {
            this.r = r;
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine($"Resp : {r.Name}");
        }

        private void DisconnectButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            mainW.Show();
            this.Close();
        }
    }
}
