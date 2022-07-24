using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                    Member m = new Member(Guid.Parse("9306ba3b-bc85-4551-883d-83dce369232d"), "", "", "", login, password, 0);
                    Member member = m.loginCheck(login, password);
                    
                    if (member != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Member : {member.Id} Name : {member.Name} ");
                        /*Aller vers page*/
                    }
                    else
                    {
                        /*Error*/
                    }
                    break;
                case "Responsable":
                    Responsible r = new Responsible(Guid.Parse("9306ba3b-bc85-4551-883d-83dce369232d"), "", "", "", login, password,null);
                    Responsible resp = r.loginCheck(login, password);
                    if (resp != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Resp : {resp.Id} Name : {resp.Name} ");
                        /*Aller vers page*/
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("null");
                        /*Error*/
                    }
                    break;
                case "Tresorier":
                    Treasurer t = new Treasurer(Guid.Parse("9306ba3b-bc85-4551-883d-83dce369232d"), "", "", "", login, password);
                    Treasurer tres = t.loginCheck(login, password);
                    if (tres != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Tres : {tres.Id} Name : {tres.Name} ");
                        /*Aller vers page*/
                    }
                    else
                    {
                        /*Error*/
                    }
                    break;
            }

        }
    }
}
