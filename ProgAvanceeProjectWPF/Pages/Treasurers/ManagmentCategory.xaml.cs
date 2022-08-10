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

namespace ProgAvanceeProjectWPF.Pages.Treasurers
{
    /// <summary>
    /// Interaction logic for ManagmentCategory.xaml
    /// </summary>
    public partial class ManagmentCategory : Page
    {
        Category cat = new Category();
        List<Category> categories = new List<Category>();
        List<string> CMBoxCat = new List<string>();
        public ManagmentCategory()
        {
            InitializeComponent();
            categories = cat.GetAllCategories();
            foreach(Category c in categories)
            {
                CMBoxCat.Add(c.NameCategory);
            }
            CMCategory.ItemsSource = CMBoxCat;
        }

        private void CMCategory_SelectionChanged(object sender, RoutedEventArgs e)
        {
            cat = categories[CMCategory.SelectedIndex];
            List<Member> members = cat.Members;

            CategoryMemberGrid.ItemsSource = members;
        }

        private void DeleteMember(object sender, RoutedEventArgs e)
        {
            Member member = (sender as FrameworkElement).DataContext as Member;
            cat.RemoveMember(member, cat);
            CategoryMemberGrid.ItemsSource = null;
            CategoryMemberGrid.ItemsSource = cat.Members;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
