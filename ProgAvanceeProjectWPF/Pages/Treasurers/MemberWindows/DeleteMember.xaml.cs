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

namespace ProgAvanceeProjectWPF.Pages.Treasurers.MemberWindows
{
    /// <summary>
    /// Interaction logic for DeleteMember.xaml
    /// </summary>
    public partial class DeleteMember : Window
    {
        Member m = new Member();
        public DeleteMember(Member m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void DeleteValidation(object sender, RoutedEventArgs e)
        {
            bool deleteStatus = m.DeleteMember(m);

            if (deleteStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans la suppression de la balade.");
            }
        }
        private void DeleteDiscard(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
