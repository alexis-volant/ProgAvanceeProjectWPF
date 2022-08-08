using ProgAvanceeProjectWPF.Pages.Treasurers.ResponsibleWindows;
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
    /// Interaction logic for ManagmentResponsible.xaml
    /// </summary>
    public partial class ManagmentResponsible : Page
    {
        Treasurer t = new Treasurer();
        List<Responsible> responsibles = new List<Responsible>();
        Responsible responsible = new Responsible();
        
        public ManagmentResponsible(Treasurer t)
        {
            InitializeComponent();
            this.t = t;
            responsibles = responsible.GetAllResponsibles();
            ManagmentResponsibleGrid.ItemsSource = responsibles;
        }

        private void AddResponsibleButton(object sender, RoutedEventArgs e)
        {
            int count = responsible.CountResponsibles();
            if(count != -1 && count < 5)
            {
                AddResponsible addResponsible = new AddResponsible();
                RefreshGrid(addResponsible);
            }
            else
            {
                MessageBox.Show("Il y a déjà un responsable pour chaque catégorie");
            }
            
        }
        private void UpdateResponsible(object sender, RoutedEventArgs e)
        {
            responsible = (sender as FrameworkElement).DataContext as Responsible;
            UpdateResponsible updateResponsible = new UpdateResponsible(responsible);
            RefreshGrid(updateResponsible);
        }
        private void DeleteResponsible(object sender, RoutedEventArgs e)
        {
            responsible = (sender as FrameworkElement).DataContext as Responsible;
            DeleteResponsible deleteResponsible = new DeleteResponsible(responsible);
            RefreshGrid(deleteResponsible);
        }
        public void RefreshGrid(Window win)
        {
            win.Closed += (ss, ee) =>
            {
                responsibles = responsible.GetAllResponsibles();
                ManagmentResponsibleGrid.ItemsSource = responsibles;
            };
            win.Show();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
