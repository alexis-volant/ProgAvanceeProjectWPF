using ProgAvanceeProjectWPF.Windows;
using System;
using System.Windows;

namespace ProjetWPFAout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button(object sender, RoutedEventArgs e)
        {
            String login = Login.Text;
            String password = Password.Password.ToString();
            
            switch (Choice.Text)
            {
                case "Membre":
                    Member m = new Member(Guid.Parse("9306ba3b-bc85-4551-883d-83dce369232d"), "", "", "", login, password);
                    Member member = m.loginCheck(login, password);
                    if (member != null)
                    {
                        MemberWindow memberW = new MemberWindow(member);
                        memberW.Show();
                        this.Close();
                    }
                    else
                    {
                        ErrorMessage();
                    }
                    Login.Text = String.Empty;
                    Password.Password = String.Empty;
                    break;
                case "Responsable":
                    Responsible r = new Responsible(Guid.Parse("9306ba3b-bc85-4551-883d-83dce369232d"), "", "", "", login, password,null);
                    Responsible resp = r.loginCheck(login, password);
                    if (resp != null)
                    {
                        ResponsibleWindow responsibleW = new ResponsibleWindow(resp);
                        responsibleW.Show();
                        this.Close();
                    }
                    else
                    {
                        ErrorMessage();
                    }
                    Login.Text = String.Empty;
                    Password.Password = String.Empty;
                    break;
                case "Tresorier":
                    Treasurer t = new Treasurer(Guid.Parse("9306ba3b-bc85-4551-883d-83dce369232d"), "", "", "", login, password);
                    Treasurer tres = t.loginCheck(login, password);
                    if (tres != null)
                    {
                        TreasurerWindow tresW = new TreasurerWindow(tres);
                        tresW.Show();
                        this.Close();
                    }
                    else
                    {
                        ErrorMessage();
                    }
                    Login.Text = String.Empty;
                    Password.Password = String.Empty;
                    break;
            }
        }

        private void ErrorMessage()
        {
            MessageBox.Show("1) Erreur dans l'encodage du login/mot de passe.\n" +
                "2) Erreur dans le choix de connexion.");
        }
    }
}
