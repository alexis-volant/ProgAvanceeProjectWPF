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

namespace ProgAvanceeProjectWPF.Pages.Members.Windows
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

            List<string> CatNamelist = new List<string>();
            List<Category> categories = category.GetAllCategories();

            //foreach (Category c in categories)
            //{
            //    CatNamelist.Add(c.NameCategory);
            //}

            CatChoice.ItemsSource = categories;
        }

        private void AddMemberCategory(object sender, RoutedEventArgs e)
        {
            Category newCategory = new Category(); ;

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
}
