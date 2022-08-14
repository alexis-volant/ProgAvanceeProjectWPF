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
    /// Interaction logic for MyMessages.xaml
    /// </summary>
    public partial class MyMessages : Page
    {
        Member member = new Member();
        Message message = new Message();    
        public MyMessages(Member m)
        {
            InitializeComponent();

            this.member = m;

            MessagesGrid.ItemsSource = member.Messages;
        }

        private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;

            NavigationService.Navigate(new MemberHub(member));

        }

        public void IsReadBtn(object sender, RoutedEventArgs e)
        {
            Message newMessage = new Message();
            newMessage = (sender as FrameworkElement).DataContext as Message;
            newMessage.IsRead=true;
            message.UpdateMessage(newMessage);
        }
    }
}
