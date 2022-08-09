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
            categories = cat.GetAllCategory();
            foreach(Category c in categories)
            {
                CMBoxCat.Add(c.NameCategory);
            }
            CMCategory.ItemsSource = CMBoxCat;
        }



        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
