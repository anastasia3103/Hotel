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
        /// <summary>
        /// Предоставляет поле для хранения количества попыток входа
        /// </summary>

        int loginAttemptCount = 0;

        public AuthorizationWindow()
        {
            InitializeComponent();
            BlockingUserByDate();
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validation()==true)
            {
                Authentication();
            }
        }
        /// <summary>
        /// Метод для валидации введенных данных.
        /// </summary>
        /// <returns> Возвращает труе, если данные прошли валидацию. Иначе - фолс. </returns> 
        public bool Validation()
        {
            //Если поля для ввода пароля и логина пусты
            if (LoginTb.Text == string.Empty && PasswordPb.Password == string.Empty)
            {
                Feedback.Warning("Поля для ввода не должны быть пустыми. Введите логин и пароль!!");
                return false;
            }
            //Иначе, если в поле для ввода логина пусто, то...
            else if (LoginTb.Text == string.Empty)
            {
                Feedback.Warning("Поля для ввода не должны быть пустыми. Введите логин!");
                return false;
            }
            else if (PasswordPb.Password == string.Empty)
            {
                Feedback.Warning("Поля для ввода не должны быть пустыми. Введите пароль!");
                return false;
            }

            return true;
        }

        /// <summary>
        ///  Метод для аутификации пользователя.
        /// </summary>
        public void Authentication()
        {
            App.currentUser = App.context.User.FirstOrDefault(user => user.Login == LoginTb.Text && user.Password == PasswordPb.Password);
            if (App.currentUser == null)
            {

                loginAttemptCount++;
                Feedback.Error($"Вы ввели неверный логин или пароль. Проверите правильно ли вы ввели свои данные! Осталось попыток: {loginAttemptCount} из 3");
                if (loginAttemptCount == 3)
                {
                    //App.currentUser.IsBlocked = true;
                    loginAttemptCount = 0;
                    Feedback.Error("Вы заблокированы. Обратитель к администратору");
                    Close();

                }

            }
            else if (App.currentUser.IsBlocked == true)
            {
                Feedback.Error("Вы заблокированы. Обратитесь к администратору!");

            }
            else if (App.currentUser.IsActivated == false)
            {
                ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
                changePasswordWindow.Show();

            }
            else
            {
                Feedback.Information("Вы успешно авторизировались!");
                switch (App.currentUser.RoleId)
                {
                    case 1: 
                        AdministratorWindow administratorWindow = new AdministratorWindow();
                        administratorWindow.Show();
                        break;
                    case 2:

                        
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        break;
                    default:
                        Feedback.Error("Роль пользователя не найдена! Доступ запрещён.");
                        break;

                }
            }
        }
        /// <summary>
        /// Метод для блокировки пользователя по дате.
        /// </summary>
        public void BlockingUserByDate()
        {
            foreach(var user in App.context.User)
            {
                if(user.RegistrationDate.AddMonths(1) <= DateTime.Now.Date && !user.IsActivated)
                {
                    user.IsBlocked = true;
                    
                }
            }
            App.context.SaveChanges();
        }


        
    }
}
