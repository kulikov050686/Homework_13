using Microsoft.Xaml.Behaviors;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace Homework_13.Behaviors
{
    /// <summary>
    /// Поведение плавного затухания окна
    /// </summary>
    public class WindowDisappearing : Behavior<Window>
    {
        /// <summary>
        /// Вызывается когда поведение добавляется в коллекцию
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Closing += OnWindowClosing;
        }

        /// <summary>
        /// Обработчик события закрытия окна
        /// </summary>        
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Window window = sender as Window;
            window.Closing -= OnWindowClosing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(2));
            anim.Completed += (s, a) => window.Close();
            window.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        /// <summary>
        /// Вызывается когда поведение удаляется из коллекции
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Closing -= OnWindowClosing;
        }
    }
}
