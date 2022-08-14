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
    /// Interaction logic for RefundWindow.xaml
    /// </summary>
    public partial class RefundWindow : Window
    {
        Treasurer t = new Treasurer();
        Message message = new Message();
        Member member = new Member();
        public RefundWindow(Treasurer t, Message message)
        {
            InitializeComponent();
            this.t = t;
            this.message = message;

            List<Member> members = member.GetAllMembers();

            CMMemberPay.ItemsSource = members;
            CMMemberReceive.ItemsSource = members;
        }

        private void Refund(object sender, RoutedEventArgs e)
        {
            Member pay = CMMemberPay.SelectedItem as Member;
            Member receive = CMMemberReceive.SelectedItem as Member;
            double amount;

            var fee = Amount.Text.Replace(',', '.');

            if (pay == null)
            {
                MessageBox.Show("Veuillez choisir le payeur.");
                return;
            }
            if (receive == null)
            {
                MessageBox.Show("Veuillez choisir le receveur.");
                return;
            }
            if (!Double.TryParse(fee, NumberStyles.Any, CultureInfo.InvariantCulture, out amount))
            {
                MessageBox.Show("Veuillez encoder un nombre correct");
                return;
            }
            
            if (pay.verifyBalance(amount))
            {
                if (t.payerConducteur(receive, amount) && t.reclamerForfait(pay, amount))
                {
                    if (message.MessageIsRead(message))
                    {
                        MessageBox.Show("Remboursement effectué.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Le message n'a pu être mis en 'lu'.");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur dans le remboursement.");
                }
            }
            else
            {
                string obj = "Alerte solde";
                string content = "Bonjour, \n\n" +
                    $"Je vous aie ajouté à la balade, vous devez au trésorier un montant de {amount}\n\n" +
                    "Bien à vous.";
                t.payerConducteur(receive, amount);
                t.reclamerForfait(pay, amount);
                message.MessageIsRead(message);
                t.envoiLettreRappel(obj,content, t, pay);
                MessageBox.Show("Remboursement effectué, avec envoie de message.");
                this.Close();
            }
        }

        private void CancelRefund(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
