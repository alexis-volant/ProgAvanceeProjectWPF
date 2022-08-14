using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgAvanceeProjectWPF.Pages.Treasurers.MoneyWindows
{
    /// <summary>
    /// Interaction logic for MessagesWindow.xaml
    /// </summary>
    public partial class MessagesWindow : Window
    {
        Treasurer t = new Treasurer();
        public MessagesWindow(Treasurer t)
        {
            InitializeComponent();
            this.t = t;

            MessagesGrid.ItemsSource = t.Messages.Where(x => x.IsRead == false).ToList();
        }

        private void OpenPaymentWindow(object sender, RoutedEventArgs e)
        {
            Message message = (sender as FrameworkElement).DataContext as Message;

            if (message.Obj.Equals("Inscription balade"))
            {
                RefundWindow RW = new RefundWindow(t,message);
                RefreshGrid(RW);
            }

            if (message.Obj.Equals("Inscription catégorie"))
            {
                RefundWindow RW = new RefundWindow(t,message);
                RefreshGrid(RW);
            }
        }

        public void RefreshGrid(Window win)
        {
            win.Closed += (ss, ee) =>
            {
                MessagesGrid.ItemsSource = t.Messages.Where(x => x.IsRead == false).ToList();
            };
            win.Show();
        }


        private void BackButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
