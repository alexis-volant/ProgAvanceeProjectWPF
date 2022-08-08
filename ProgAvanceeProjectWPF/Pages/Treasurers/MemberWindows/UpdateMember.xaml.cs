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
    /// Interaction logic for UpdateMember.xaml
    /// </summary>
    public partial class UpdateMember : Window
    {
        Member m = new Member();
        public UpdateMember(Member m)
        {
            InitializeComponent();
            this.m = m;

            UpdateName.Text = m.Name;
            UpdateFirstName.Text = m.FirstName;
            UpdateTelephone.Text = m.Tel;
            UpdateLogin.Text = m.Login;
            UpdatePassWord.Text = m.PassWord;
            UpdateBalance.Text = String.Format("{0:0.00}", Convert.ToDouble(m.Balance.ToString()));
        }

        private void UpdateValidation(object sender, RoutedEventArgs e)
        {
            string UpdateN;
            string UpdateF;
            string UpdateT;
            string UpdateL;
            string UpdateP;
            double UpdateB;

            if (UpdateName.Text.Length == 0)
            {
                MessageBox.Show("Le nom du membre ne peut-être vide.");
                return;
            }
            if (UpdateFirstName.Text.Length == 0)
            {
                MessageBox.Show("Le prénom du membre ne peut-être vide.");
                return;
            }
            if (UpdateTelephone.Text.Length == 0)
            {
                MessageBox.Show("Le téléphone du membre ne peut-être vide.");
                return;
            }
            if (UpdateLogin.Text.Length == 0)
            {
                MessageBox.Show("Le login du membre ne peut-être vide.");
                return;
            }
            if (UpdatePassWord.Text.Length == 0)
            {
                MessageBox.Show("Le mot de passe du membre ne peut-être vide.");
                return;
            }

            UpdateN = UpdateName.Text;
            UpdateF = UpdateFirstName.Text;
            UpdateT = UpdateTelephone.Text;
            UpdateL = UpdateLogin.Text;
            UpdateP = UpdatePassWord.Text;
            UpdateB = UpdateBalance.Text.Length == 0 ? 0 : Convert.ToDouble(UpdateBalance.Text);

            bool updateStatus = m.UpdateMember(m, UpdateN, UpdateF, UpdateT, UpdateL, UpdateP, UpdateB);

            if (updateStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'encodage du membre.");
            }
        }
        private void UpdateDiscard(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
