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

namespace ProgAvanceeProjectWPF.Pages.Treasurers
{
    /// <summary>
    /// Interaction logic for ManagmentResponsible.xaml
    /// </summary>
    public partial class ManagmentResponsible : Page
    {
        Treasurer t = new Treasurer();
        Responsible responsible = new Responsible();
        List<Responsible> responsibles = new List<Responsible>();
        Responsible selectedResponsible = new Responsible();
        Category cat = new Category();
        public ManagmentResponsible(Treasurer t)
        {
            InitializeComponent();
            this.t = t;
            responsibles = responsible.GetAllResponsibles();
            ManagmentResponsibleGrid.ItemsSource = responsibles;

            AddGrid.Visibility = Visibility.Hidden;
            UpdateGrid.Visibility = Visibility.Hidden;
            DeleteGrid.Visibility = Visibility.Hidden;
        }

        private void AddResponsibleButton(object sender, RoutedEventArgs e)
        {
            AddCategory.ItemsSource = cat.GetAllWOResponsible();
            AddGrid.Visibility = Visibility.Visible;
            UpdateGrid.Visibility = Visibility.Hidden;
            DeleteGrid.Visibility = Visibility.Hidden;
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
            if (AddCategory.Text.Length == 0)
            {
                MessageBox.Show("Vous n'avez pas choisit de catégorie.");
                return;
            }

            Name = AddName.Text;
            FirstName = AddFirstName.Text;
            Tel = AddTelephone.Text;
            Login = AddLogin.Text;
            Password = AddPassWord.Text;
            category = cat.GetCategoryByName(AddCategory.Text);

            bool addStatus = selectedResponsible.AddResponsible(Name, FirstName, Tel, Login, Password, category);

            if (addStatus)
            {
                responsibles = selectedResponsible.GetAllResponsibles();
                ManagmentResponsibleGrid.ItemsSource = responsibles;
                AddGrid.Visibility = Visibility.Hidden;
                AddName.Text = String.Empty;
                AddFirstName.Text = String.Empty;
                AddTelephone.Text = String.Empty;
                AddLogin.Text = String.Empty;
                AddPassWord.Text = String.Empty;
                AddCategory.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Erreur dans l'ajout du membre.");
            }
        }
        private void AddDiscard(object sender, RoutedEventArgs e)
        {
            AddName.Text = String.Empty;
            AddFirstName.Text = String.Empty;
            AddTelephone.Text = String.Empty;
            AddLogin.Text = String.Empty;
            AddPassWord.Text = String.Empty;
            AddCategory.Text = String.Empty;
            AddGrid.Visibility = Visibility.Hidden;
        }

        private void UpdateMember(object sender, RoutedEventArgs e)
        {
            selectedResponsible = (sender as FrameworkElement).DataContext as Responsible;

            UpdateName.Text = selectedResponsible.Name;
            UpdateFirstName.Text = selectedResponsible.FirstName;
            UpdateTelephone.Text = selectedResponsible.Tel;
            UpdateLogin.Text = selectedResponsible.Login;
            UpdatePassWord.Text = selectedResponsible.PassWord;

            AddGrid.Visibility = Visibility.Hidden;
            UpdateGrid.Visibility = Visibility.Visible;
            DeleteGrid.Visibility = Visibility.Hidden;
        }
        private void UpdateValidation(object sender, RoutedEventArgs e)
        {
            string UpdateN = UpdateName.Text;
            string UpdateF = UpdateFirstName.Text;
            string UpdateT = UpdateTelephone.Text;
            string UpdateL = UpdateLogin.Text;
            string UpdateP = UpdatePassWord.Text;

            bool updateStatus = selectedResponsible.UpdateResponsible(selectedResponsible, UpdateN, UpdateF, UpdateT, UpdateL, UpdateP);

            if (updateStatus)
            {
                responsibles = selectedResponsible.GetAllResponsibles();
                ManagmentResponsibleGrid.ItemsSource = responsibles;
                UpdateGrid.Visibility = Visibility.Hidden;
                UpdateName.Text = String.Empty;
                UpdateFirstName.Text = String.Empty;
                UpdateTelephone.Text = String.Empty;
                UpdateLogin.Text = String.Empty;
                UpdatePassWord.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Erreur dans l'encodage du responsable.");
            }
        }
        private void UpdateDiscard(object sender, RoutedEventArgs e)
        {
            UpdateGrid.Visibility = Visibility.Hidden;
        }

        private void DeleteMember(object sender, RoutedEventArgs e)
        {
            selectedResponsible = (sender as FrameworkElement).DataContext as Responsible;

            AddGrid.Visibility = Visibility.Hidden;
            UpdateGrid.Visibility = Visibility.Hidden;
            DeleteGrid.Visibility = Visibility.Visible;
        }
        private void DeleteValidation(object sender, RoutedEventArgs e)
        {
            bool deleteStatus = selectedResponsible.DeleteResponsible(selectedResponsible);

            if (deleteStatus)
            {
                responsibles = selectedResponsible.GetAllResponsibles();
                ManagmentResponsibleGrid.ItemsSource = responsibles;
                DeleteGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Erreur dans la suppression de la balade.");
            }
        }
        private void DeleteDiscard(object sender, RoutedEventArgs e)
        {
            DeleteGrid.Visibility = Visibility.Hidden;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
