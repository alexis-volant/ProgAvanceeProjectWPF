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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgAvanceeProjectWPF.Pages.Treasurers.MoneyWindows
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        Treasurer tres = new Treasurer();
        Member member = new Member();
        Message message = new Message();
        public MessageWindow(Treasurer t, Member m)
        {
            InitializeComponent();
            this.tres = t;
            this.member = m;

            string objet = "Paiement de cotisation";
            string contenu = "Bonjour, \n\n" +
                                "Je vous envoie ce message afin de régler la cotisation annuelle du club.\n" +
                                "Bien à vous.";

            ObjetMessage.Text = objet;
            ContenuMessage.Text = contenu;
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            bool addStatus = message.AddMessage(ObjetMessage.Text, ContenuMessage.Text, tres, member);

            if (addStatus)
            {
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
