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
    /// Interaction logic for UpdateResponsible.xaml
    /// </summary>
    public partial class UpdateResponsible : Window
    {
        Responsible r = new Responsible();
        public UpdateResponsible(Responsible r)
        {
            InitializeComponent();
            this.r = r;

            UpdateName.Text = r.Name;
            UpdateFirstName.Text = r.FirstName;
            UpdateTelephone.Text = r.Tel;
            UpdateLogin.Text = r.Login;
            UpdatePassWord.Text = r.PassWord;
        }

        private void UpdateValidation(object sender, RoutedEventArgs e)
        {
            string UpdateN = UpdateName.Text;
            string UpdateF = UpdateFirstName.Text;
            string UpdateT = UpdateTelephone.Text;
            string UpdateL = UpdateLogin.Text;
            string UpdateP = UpdatePassWord.Text;

            bool updateStatus = r.UpdateResponsible(r, UpdateN, UpdateF, UpdateT, UpdateL, UpdateP);

            if (updateStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'encodage du responsable.");
            }
        }
        private void UpdateDiscard(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
