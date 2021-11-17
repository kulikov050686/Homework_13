using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace Homework_13.Behaviors
{
    /// <summary>
    /// Положение информационного окна
    /// </summary>
    public class InfoWinowLocation : Behavior<Window>
    {
        /// <summary>
        /// Вызывается когда поведение добавляется в коллекцию
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        /// <summary>
        /// Обработчик события создания информационного окна
        /// </summary>        
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            if(App.Current.MainWindow is Window mainWindow)
            {
                if(sender is Window childWindow)
                {
                    childWindow.Top = (mainWindow.Top + mainWindow.Height - 10) - childWindow.Height;
                    childWindow.Left = (mainWindow.Left + mainWindow.Width - 10) - childWindow.Width;
                }
            }            
        }

        /// <summary>
        /// Вызывается когда поведение удаляется из коллекции
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}
