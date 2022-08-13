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
    /// Interaction logic for AddMoneyWindow.xaml
    /// </summary>
    public partial class AddMoneyWindow : Window
    {
        Member member = new Member();
        public AddMoneyWindow(Member member)
        {
            InitializeComponent();
            this.member = member;
            Person.Text = $"{member.Name} {member.FirstName}";
        }

        private void AddMoney(object sender, RoutedEventArgs e)
        {
            double addedMoney;
            var solde = AddedMoney.Text.Replace(',', '.');

            if (!Double.TryParse(solde, NumberStyles.Any, CultureInfo.InvariantCulture, out addedMoney))
            {
                MessageBox.Show("Veuillez encoder un nombre correct");
                return;
            }

            member.Balance += addedMoney;

            if(member.UpdateMember(member))
            {
                MessageBox.Show("Solde mis à jour.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans la mise à jour du solde.");
            }
        }

        private void CancelAdd(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
