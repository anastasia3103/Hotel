using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.AppData
{
    /// <summary>
    /// Класс для реализации обратной связи с пользователем
    /// </summary>
    internal class Feedback
    {
        /// <summary>
        /// Отображает сообщение с ошибкой.
        /// </summary>
        /// <param name="text">Текст ошибки.</param>
        /// <param name="title">Заголовок ошибки.</param>
        public static void Error(string text, string title = "Ошибка")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Отображает сообщение с предупреждением.
        /// </summary>
        /// <param name="text">Текст предупреждения.</param>
        /// <param name="title">Заголовок предупреждения.</param>
        public static void Warning(string text, string title = "Предупреждение")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        /// <summary>
        /// Отображает сообщение с информацией.
        /// </summary>
        /// <param name="text">Текст информации.</param>
        /// <param name="title">Заголовок информации.</param>
        public static void Information(string text, string title = "Информация")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
