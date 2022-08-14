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

namespace ProgAvanceeProjectWPF.Pages.Members.Windows.Categories
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        Member member = new Member();
        Category category = new Category();
        public AddCategory(Member m)
        {
            InitializeComponent();

            this.member = m;
            List<Category> categories = category.GetAllCategories();
            CatChoice.ItemsSource = categories;
        }

        private void AddMemberCategory(object sender, RoutedEventArgs e)
        {
            Category newCategory = new Category();
            int nbrCat = member.Categories.Count;
            double amount=0.00;
            

            if (nbrCat <= 0)
            {
                amount = 20.00;
                if (!member.verifyBalance(amount))
                {
                    MessageBox.Show("Vous n'avez pas assez de fond");
                    this.Close();
                    return;
                }
            }
            else if (nbrCat > 0)
            {
                amount = 5.00;
                if (!member.verifyBalance(amount))
                {
                    MessageBox.Show("Vous n'avez pas assez de fond");
                    this.Close();
                    return;

                }
            }

            if (CatChoice.SelectedItem == null || CatChoice.SelectedItem.GetType() != typeof(Category))
            {
                MessageBox.Show("Veuillez choisir une catégorie");
                return;
            }
            else
            {
                newCategory = CatChoice.SelectedItem as Category;
                
                foreach(Category cat in member.Categories)
                {
                    if (cat.Num == newCategory.Num)
                    {
                        MessageBox.Show("vous êtes déjà dans cette catégorie");
                        
                        this.Close();
                        return;
                    }

                }
                
                bool addStatus = member.AddCategory(newCategory, member);

                if (addStatus)
                {
                    member.calculBalance(-amount);
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
