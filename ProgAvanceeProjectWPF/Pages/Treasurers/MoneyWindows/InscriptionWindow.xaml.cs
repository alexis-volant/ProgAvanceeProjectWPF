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

namespace ProgAvanceeProjectWPF.Pages.Treasurers.MoneyWindows
{
    /// <summary>
    /// Interaction logic for InscriptionWindow.xaml
    /// </summary>
    public partial class InscriptionWindow : Window
    {
        Message message = new Message();
        Member member = new Member();
        double amount = 5;
        public InscriptionWindow(Message message)
        {
            InitializeComponent();
            this.message = message;
            List<Member> members = member.GetAllMembers();

            CMMemberPay.ItemsSource = members;
            Montant.Text = $"Montant à payer {amount}€";
        }

        public void Pay(object sender, RoutedEventArgs e)
        {
            Member pay = CMMemberPay.SelectedItem as Member;

            if (pay == null)
            {
                MessageBox.Show("Veuillez choisir le payeur.");
                return;
            }

            if (pay.verifyBalance(amount))
            {
                pay.calculBalance(-amount);
                if (member.UpdateMember(pay))
                {
                    message.MessageIsRead(message);
                    MessageBox.Show("Paiement effectué.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur dans le paiement.");
                }
            }
            else
            {
                MessageBox.Show("Le solde est insuffisant.");
            }
        }

        private void CancelPayment(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
