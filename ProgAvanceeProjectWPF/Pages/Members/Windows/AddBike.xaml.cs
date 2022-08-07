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
            double AddBikeWeigth;
            double AddBikeLength;

            if (AddType.Equals(""))
            {
                MessageBox.Show("Le type ne peut-être vide.");
                return;
            }


            AddBikeType = AddType.Text;

            AddBikeWeigth = AddWeigth.Text.Length == 0 ? 0 : Convert.ToDouble(AddWeigth.Text);

            AddBikeLength = AddLength.Text.Length == 0 ? 0 : Convert.ToDouble(AddLength.Text);

            bool addStatus = bike.AddBike(AddBikeType, AddBikeWeigth, AddBikeLength, member);

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
