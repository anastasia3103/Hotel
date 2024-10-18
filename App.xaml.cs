using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Представляет контекст даннных для взаимодействия с БД
        /// </summary>
        public static Entities context = new Entities();

        /// <summary>
        /// Предаставляет поле для хранения пользователя, вошедшего в систему
        /// </summary>
        public static User currentUser;
    }
}
