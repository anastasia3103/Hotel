﻿using Hotel.View.Pages;
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
using System.Windows.Shapes;

namespace Hotel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new UserListPage());
        }

        private void UsersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserListPage());
        }

        private void RoomsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RoomListPage());
        }
    }
}
