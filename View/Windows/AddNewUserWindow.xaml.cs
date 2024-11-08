using Hotel.AppData;
using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для AddNewUserWindow.xaml
    /// </summary>
    public partial class AddNewUserWindow : Window
    {
        public AddNewUserWindow()
        {
            InitializeComponent();
        }

       

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUser();
        }

        public void AddUser()
        {
            try
            {
                User newUser = new User()
                {
                    Fullname = FullnameTb.Text,
                    Login = LoginTb.Text,
                    Password = PasswordPb.Password,
                    RegistrationDate = DateTime.Now.Date,
                    IsActivated = false,
                    IsBlocked = false,
                    RoleId = 2

                };

                App.context.User.Add(newUser);
                App.context.SaveChanges();
                Feedback.Information("Пользователь успешно добавлен");

                DialogResult = true;

            }
            catch (DbUpdateException exception)
            {

                Feedback.Error($"Пользователь с таким логином уже существует. {exception.Message}");

                DialogResult = false;
            }
            catch (Exception exception)
            {

                Feedback.Error($"Ошибка при добавлении пользователя. {exception.Message}");

                DialogResult = false;
            }
        }
    }
}
