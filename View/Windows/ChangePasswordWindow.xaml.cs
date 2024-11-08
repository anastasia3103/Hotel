using Hotel.AppData;
using Hotel.Model;
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
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword();
        }

        public void ChangePassword()
        {

            if (string.IsNullOrEmpty(OldPasswordPb.Password)
               || string.IsNullOrEmpty(OldPasswordPb.Password)
               || string.IsNullOrEmpty(OldPasswordPb.Password))
            {
                Feedback.Error("Все поля обязательны для заполнения!Заполните каждое поле");
            }

            else if (OldPasswordPb.Password != App.currentUser.Password)
            {
                Feedback.Error("Неверно введен текущий пароль! Попробуйте снова");
            }
            else if (NewPasswordPb.Password != AcceptPasswordPb.Password)
            {
                Feedback.Error("Новые пароли не совпадают. Попробуйте снова");
            }
            else if (OldPasswordPb.Password == NewPasswordPb.Password)
            {
                Feedback.Error("Старые и новые пароли совпадают! Придумайте новый пароль");
            }
            else
            {
                App.currentUser.Password = NewPasswordPb.Password;
                App.currentUser.IsActivated = true;

                App.context.SaveChanges();

                Feedback.Information("Пароль успешно изменен");

                Close();
            }
        }
    }
}
