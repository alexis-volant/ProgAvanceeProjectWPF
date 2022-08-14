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

namespace ProgAvanceeProjectWPF.Pages.Members.Windows.Bikes
{
    /// <summary>
    /// Interaction logic for AddBike.xaml
    /// </summary>
    public partial class AddBike : Window
    {
        Bike bike = new Bike();
        Member member = new Member();
        Category category = new Category();

        public AddBike(Member m)
        {
            InitializeComponent();
            this.member = m;

            List<string> CatNamelist = new List<string>();
            List<Category> categories = category.GetAllCategories();

            foreach (Category c in categories)
            {
                CatNamelist.Add(c.NameCategory);
            }

            AddType.ItemsSource = CatNamelist;

        }

        private void AddBikeValidation(object sender, RoutedEventArgs e)
        {
            string AddBikeType;
            double AddBikeWeight;
            double AddBikeLength;

            if (AddType.Text.Equals("") || AddType.Text.Equals("--choisir un type--"))
            {
                MessageBox.Show("Veuillez choisir un type");
                return;
            }
            else
            {
                AddBikeType = AddType.Text;
            }

            var weigth = AddWeight.Text.Replace(',', '.');

            if (!Double.TryParse(weigth, NumberStyles.Any,CultureInfo.InvariantCulture, out AddBikeWeight))
            {
                MessageBox.Show("Veuillez encoder un nombre correct");
                return;
            }
            
            var length = AddLength.Text.Replace(',', '.');
            if (!Double.TryParse(length, NumberStyles.Any, CultureInfo.InvariantCulture, out AddBikeLength))
            {
                MessageBox.Show("Veuillez encoder un nombre correct");
                return;
            }
           

            bool addStatus = bike.CreateBike(AddBikeType, AddBikeWeight, AddBikeLength, member);

            if (addStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'ajout du velo.");
                this.Close();
            }
        }
    }
}
