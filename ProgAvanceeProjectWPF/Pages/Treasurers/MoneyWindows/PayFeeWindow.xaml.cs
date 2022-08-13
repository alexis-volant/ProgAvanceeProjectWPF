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

namespace ProgAvanceeProjectWPF.Pages.Treasurers.MoneyWindows
{
    /// <summary>
    /// Interaction logic for PayFeeWindow.xaml
    /// </summary>
    public partial class PayFeeWindow : Window
    {
        Member member = new Member();
        int total = 0;
        public PayFeeWindow(Member member)
        {
            InitializeComponent();
            this.member = member;
            Person.Text = $"{member.Name} {member.FirstName}";
            total = (member.Categories.Count * 5) + 15;
            TotalFee.Text = total.ToString();
        }

        private void PayFee(object sender, RoutedEventArgs e)
        {
            if(member.verifyBalance(member.Balance, total))
            {
                member.Balance -= Convert.ToDouble(total);
                member.DatePayment = DateTime.Now;
                member.PaymentCheck = true;
                if (member.UpdateMember(member))
                {
                    MessageBox.Show("Cotisation payée.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur dans le paiement de la cotisation.");
                }
            }
            else
            {
                MessageBox.Show("Le solde est insuffisant pour payer la cotisation.");
            }

            this.Close();
        }

        private void CancelPayment(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
