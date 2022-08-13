using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgAvanceeProjectWPF.Pages.Treasurers.MoneyWindows
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        Member member = new Member();
        Treasurer tres = new Treasurer();
        Message message = new Message();
        public MessageWindow(Member member, Treasurer t)
        {
            InitializeComponent();
            this.member = member;
            this.tres = t;

            int total = (member.Categories.Count * 5) + 15;

            string objet = "Paiement de cotisation";
            string contenu = "Bonjour, \n\n" +
                             "Je vous envoie ce message afin de régler la cotisation annuelle du club.\n" +
                             $"Votre cotisation s'élève à {total}€.\n" +
                             "Veuillez vous adresser au trésorier afin de régler ce montant.\n\n" +
                             "Bien à vous.";
            ObjetMessage.Text = objet;
            ContenuMessage.Text = contenu;
            Person.Text = $"{member.Name} {member.FirstName}";
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            bool addStatus = message.AddMessage(ObjetMessage.Text, ContenuMessage.Text, tres, member);

            if (addStatus)
            {
                MessageBox.Show("Message envoyé.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'envoi du message.");
            }
        }

        private void CancelMessage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
