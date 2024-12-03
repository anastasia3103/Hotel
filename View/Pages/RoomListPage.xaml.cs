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
    /// Логика взаимодействия для RoomListPage.xaml
    /// </summary>
    public partial class RoomListPage : Page
    {
        public RoomListPage()
        {
            InitializeComponent();
            RoomsLb.ItemsSource=App.context.Room.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FilterByCategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
