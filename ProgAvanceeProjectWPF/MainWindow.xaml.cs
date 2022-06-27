using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetWPFAout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);
            DAO<Bike> bikeDAO = adf.GetBikeDAO();
            List<Bike> bikes = bikeDAO.FindAll();*/


            BikeDAO bikeDAO = new BikeDAO();
            Member m = new Member(Guid.Parse("771d12f2-7c93-4320-80cd-3180a8747143"), "Martens", "Rémi", "0492821292", "remi", "1234", 0);

            List<Bike> bikes = bikeDAO.FindAllByMember(m);

            System.Diagnostics.Debug.WriteLine(bikes[0].IdBike);
        }
    }
}
