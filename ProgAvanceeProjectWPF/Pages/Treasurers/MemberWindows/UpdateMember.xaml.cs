using System;
using System.Collections.Generic;
using System.Globalization;
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

            var Solde = UpdateBalance.Text.Replace(',', '.');

            if (!Double.TryParse(Solde, NumberStyles.Any, CultureInfo.InvariantCulture, out UpdateB))
            {
                MessageBox.Show("Veuillez encoder un nombre correct");
                return;
            }

            m.Name = UpdateName.Text;
            m.FirstName = UpdateFirstName.Text;
            m.Tel = UpdateTelephone.Text;
            m.Login = UpdateLogin.Text;
            m.PassWord = UpdatePassWord.Text;
            m.Balance = UpdateB;

            if (m.UpdateMember(m))
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
