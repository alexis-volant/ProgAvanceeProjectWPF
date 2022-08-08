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

namespace ProgAvanceeProjectWPF.Pages.Treasurers.ResponsibleWindows
{
    /// <summary>
    /// Interaction logic for AddResponsible.xaml
    /// </summary>
    public partial class AddResponsible : Window
    {
        Responsible r = new Responsible();
        Category cat = new Category();
        public AddResponsible()
        {
            InitializeComponent();
            AddCategory.ItemsSource = cat.GetAllWOResponsible();
        }

        private void AddValidation(object sender, RoutedEventArgs e)
        {
            string Name;
            string FirstName;
            string Tel;
            string Login;
            string Password;
            Category category;

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
            if(AddCategory.Text.Length == 0)
            {
                MessageBox.Show("Choisissez une catégorie.");
                return;
            }

            Name = AddName.Text;
            FirstName = AddFirstName.Text;
            Tel = AddTelephone.Text;
            Login = AddLogin.Text;
            Password = AddPassWord.Text;
            category = AddCategory.SelectedItem as Category;
            category = category.GetCategory(category.Num);

            bool addStatus = r.AddResponsible(Name, FirstName, Tel, Login, Password, category);

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
