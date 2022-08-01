﻿using System;
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
    /// Interaction logic for ManagmentMember.xaml
    /// </summary>
    public partial class ManagmentMember : Page
    {
        Treasurer t = new Treasurer();
        Member member = new Member();
        List<Member> members = new List<Member>();
        Member selectedMember = new Member();

        public ManagmentMember(Treasurer t)
        {
            InitializeComponent();
            this.t = t;
            members = member.GetAllMembers();
            ManagmentMemberGrid.ItemsSource = members;

            /*AddGrid.Visibility = Visibility.Hidden;*/
            UpdateGrid.Visibility = Visibility.Hidden;
            /*DeleteGrid.Visibility = Visibility.Hidden;*/
        }

        private void UpdateMember(object sender, RoutedEventArgs e)
        {
            selectedMember = (sender as FrameworkElement).DataContext as Member;

            UpdateName.Text = selectedMember.Name;
            UpdateFirstName.Text = selectedMember.FirstName;
            UpdateTelephone.Text = selectedMember.Tel;
            UpdateLogin.Text = selectedMember.Login;
            UpdatePassWord.Text = selectedMember.PassWord;
            UpdateBalance.Text = String.Format("{0:0.00}", Convert.ToDouble(selectedMember.Balance.ToString()));

            /*AddGrid.Visibility = Visibility.Hidden;*/
            UpdateGrid.Visibility = Visibility.Visible;
            /*DeleteGrid.Visibility = Visibility.Hidden;*/
        }

        private void UpdateValidation(object sender, RoutedEventArgs e)
        {
            string UpdateN = UpdateName.Text;
            string UpdateF = UpdateFirstName.Text;
            string UpdateT = UpdateTelephone.Text;
            string UpdateL = UpdateLogin.Text;
            string UpdateP = UpdatePassWord.Text;
            float UpdateB = UpdateBalance.Text.Length == 0 ? 0 : float.Parse(UpdateBalance.Text);

            bool updateStatus = selectedMember.UpdateMember(selectedMember, UpdateN, UpdateF, UpdateT, UpdateL, UpdateP, UpdateB);

            if (updateStatus)
            {
                members = selectedMember.GetAllMembers();
                ManagmentMemberGrid.ItemsSource = members;
                UpdateGrid.Visibility = Visibility.Hidden;
                UpdateName.Text = String.Empty;
                UpdateFirstName.Text = String.Empty;
                UpdateTelephone.Text = String.Empty;
                UpdateLogin.Text = String.Empty;
                UpdatePassWord.Text = String.Empty;
                UpdateBalance.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Erreur dans l'encodage du membre.");
            }
        }

        private void UpdateDiscard(object sender, RoutedEventArgs e)
        {
            UpdateGrid.Visibility = Visibility.Hidden;
        }

        private void DeleteMember(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Content = null;
            NavigationService.GoBack();
        }
    }
}
