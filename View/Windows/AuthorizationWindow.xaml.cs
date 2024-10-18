using Hotel.AppData;
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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            //Если поля для ввода пароля и логина пусты
            if (LoginTb.Text == string.Empty && PasswordPb.Password == string.Empty)
            {
                Feedback.Warning("Поля для ввода не должны быть пустыми. Введите логин и пароль!!");
            }
            //Иначе, если в поле для ввода логина пусто, то...
            else if(LoginTb.Text == string.Empty)
            {
                Feedback.Warning("Поля для ввода не должны быть пустыми. Введите логин!");
            }
            else if(PasswordPb.Password == string.Empty)
            {
                Feedback.Warning("Поля для ввода не должны быть пустыми. Введите пароль!");
            }
            //Иначе логин и пароль был введен и проверка на правильност должна начаться
            else
            {
                //Проверка данных

                App.currentUser = App.context.User.FirstOrDefault(user=>user.Login == LoginTb.Text && user.Password == PasswordPb.Password);
                if(App.currentUser == null)
                {
                    Feedback.Error("Вы ввели неверный логин или пароль. Проверите правильно ли вы ввели свои данные");

                }
                else if (App.currentUser.IsActivated == false)
                    {
                    ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
                    
                }
            }
        }
    }
}
