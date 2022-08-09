using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ProgAvanceeProjectWPF.Pages.Members
{
    /// <summary>
    /// Interaction logic for MemberRide.xaml
    /// </summary>
    public partial class MemberInscription : Page
    {
        List<Ride> rides = new List<Ride>();
        Ride ride = new Ride();
        Member member = new Member();
        Category category = new Category();
        public MemberInscription(Member m)
        {
            InitializeComponent();

            this.member = m;

            List<string> CatNamelist = new List<string>(); 
            foreach (Category c in member.Categories)
            {
                CatNamelist.Add(c.NameCategory);
            }
            CatChoice.ItemsSource = CatNamelist;
        }

        private void CatChoice_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
            int idCategory = CatChoice.SelectedIndex;
            idCategory++;

            //if (!String.IsNullOrEmpty(textBoxRide.Text))
            //{
            //    textBoxRide.Clear();
            //}

            List<Ride> rides = ride.GetRidesByCategory(idCategory);

            if (rides.Any())
            {
                MemberRideGrid.ItemsSource = rides;
            }
            else
            {
                MessageBox.Show("Pas de balades pour cette catégorie");
            }
        }

        private void RideInscription(object sender, RoutedEventArgs e)
        {
            Ride selectedRide = new Ride();
        }

        private void AddMemberCategory(object sender, RoutedEventArgs e)
        {
            Category newCategory = new Category();

            if (CatChoice.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir une catégorie");

            }
            else
            {
                newCategory = (Category)CatChoice.SelectedItem;
                //Why
                if (member.Categories.Contains(newCategory))
                {
                    MessageBox.Show("vous êtes déjà dans cette catégorie");
                    this.Close();
                }
                else
                {
                    bool addStatus = member.AddCategory(newCategory, member);

                    if (addStatus)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur dans l'ajout de la catégorie");
                        this.Close();
                    }
                }
            

        }
    }
}
