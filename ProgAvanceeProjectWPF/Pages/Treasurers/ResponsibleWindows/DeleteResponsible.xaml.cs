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

namespace ProgAvanceeProjectWPF.Pages.Treasurers.ResponsibleWindows
{
    /// <summary>
    /// Interaction logic for DeleteResponsible.xaml
    /// </summary>
    public partial class DeleteResponsible : Window
    {
        Responsible r = new Responsible();
        public DeleteResponsible(Responsible r)
        {
            InitializeComponent();
            this.r = r;
        }

        private void DeleteValidation(object sender, RoutedEventArgs e)
        {
            bool deleteStatus = r.DeleteResponsible(r);

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
