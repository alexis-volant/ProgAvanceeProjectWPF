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

namespace ProgAvanceeProjectWPF.Pages.Members
{
    /// <summary>
    /// Interaction logic for MemberRide.xaml
    /// </summary>
    public partial class MemberRide : Page
    {
        List<Ride> rides = new List<Ride>();
        Ride ride = new Ride();
        Member member = new Member();
        Category category = new Category();
        public MemberRide(Member m)
        {
            InitializeComponent();
            this.member = m;

            List<string> CatNamelist = new List<string>();
            List<Category> categories = category.GetCategoriesByMember(m);
            foreach (Category c in categories)
            {
                CatNamelist.Add(c.NameCategory);
            }
            CatChoice.ItemsSource = CatNamelist;

            //List<Ride> rides = ride.GetRidesByCategory(int);
            //MemberRideGrid.ItemsSource = rides;
        }
    }
}
