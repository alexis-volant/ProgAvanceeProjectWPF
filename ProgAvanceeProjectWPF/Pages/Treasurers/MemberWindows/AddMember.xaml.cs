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
    /// Interaction logic for AddMember.xaml
    /// </summary>
    public partial class AddMember : Window
    {
        Member member = new Member();
        Category cat = new Category();
        List<Category> categories = new List<Category>();
        List<string> CMBoxCat = new List<string>();
        List<Member> members = new List<Member>();
        public AddMember()
        {
            InitializeComponent();

            categories = cat.GetAllCategories();
            foreach (Category c in categories)
            {
                CMBoxCat.Add(c.NameCategory);
            }
            CMCategory.ItemsSource = CMBoxCat;
        }

        private void CMCategory_SelectionChanged(object sender, RoutedEventArgs e)
        {
            cat = categories[CMCategory.SelectedIndex];
        }

        private void AddValidation(object sender, RoutedEventArgs e)
        {
            string Name;
            string FirstName;
            string Tel;
            string Login;
            string Password;
            double Balance;

            if (AddName.Text.Length == 0)
            {
                MessageBox.Show("Le nom du membre ne peut-être vide.");
                return;
            }
            if (AddFirstName.Text.Length == 0)
            {
                MessageBox.Show("Le prénom du membre ne peut-être vide.");
                return;
            }
            if (AddTelephone.Text.Length == 0)
            {
                MessageBox.Show("Le téléphone du membre ne peut-être vide.");
                return;
            }
            if (AddLogin.Text.Length == 0)
            {
                MessageBox.Show("Le login du membre ne peut-être vide.");
                return;
            }
            if (AddPassWord.Text.Length == 0)
            {
                MessageBox.Show("Le mot de passe du membre ne peut-être vide.");
                return;
            }

            Name = AddName.Text;
            FirstName = AddFirstName.Text;
            Tel = AddTelephone.Text;
            Login = AddLogin.Text;
            Password = AddPassWord.Text;
            var Solde = AddBalance.Text.Replace(',', '.');

            if (!Double.TryParse(Solde, NumberStyles.Any, CultureInfo.InvariantCulture, out Balance))
            {
                MessageBox.Show("Veuillez encoder un nombre correct");
                return;
            }

            bool addStatus = member.AddMember(Name, FirstName, Tel, Login, Password, Balance, cat);

            if (addStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'ajout du membre.");
            }
        }
        private void AddDiscard(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
