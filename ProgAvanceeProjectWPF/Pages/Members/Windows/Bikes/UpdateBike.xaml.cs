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

namespace ProgAvanceeProjectWPF.Pages.Members.Windows.Bikes
{
    /// <summary>
    /// Interaction logic for UpdateBike.xaml
    /// </summary>
    public partial class UpdateBike : Window
    {
        Bike selectedBike = new Bike();
        Bike bike = new Bike();
        Member member = new Member();
        Category category = new Category(); 
        public UpdateBike(Member m,Bike b )
        {
            InitializeComponent();
            this.member = m;
            this.selectedBike = b;

            List<string> CatNamelist = new List<string>();
            List<Category> categories = category.GetAllCategories();

            foreach (Category c in categories)
            {
                CatNamelist.Add(c.NameCategory);
            }

            UpdateType.ItemsSource = CatNamelist;

            UpdateType.Text = selectedBike.Type;
            UpdateLength.Text = selectedBike.Length.ToString();
            UpdateWeight.Text = selectedBike.Weight.ToString();
        }

        private void UpdateBikeValidation(object sender, RoutedEventArgs e)
        {

            string UpdateBikeType;
            double UpdateBikeWeight;
            double UpdateBikeLength;

            if (UpdateType.Equals(""))
            {
                MessageBox.Show("Le type ne peut-être vide.");
                return;
            }


            UpdateBikeType = UpdateType.Text;

            UpdateBikeWeight = UpdateWeight.Text.Length == 0 ? 0 : Convert.ToDouble(UpdateWeight.Text);

            UpdateBikeLength = UpdateLength.Text.Length == 0 ? 0 : Convert.ToDouble(UpdateLength.Text);

            bool updateStatus = selectedBike.UpdateBike(selectedBike, UpdateBikeType, UpdateBikeWeight, UpdateBikeLength);

            if (updateStatus)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur dans l'encodage de la date, ou du prix.");
                this.Close();
            }
        }
    }
}
