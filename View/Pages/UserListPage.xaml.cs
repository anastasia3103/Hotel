﻿using Hotel.View.Windows;
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

namespace Hotel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();


            UserLv.ItemsSource = App.context.User.ToList();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewUserWindow addNewUserWindow = new AddNewUserWindow();
            if (addNewUserWindow.ShowDialog() == true)
            {
                UserLv.ItemsSource = App.context.User.ToList();
            }
        }

        private void UserLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
