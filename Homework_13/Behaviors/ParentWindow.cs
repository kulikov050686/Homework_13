using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace Homework_13.Behaviors
{
    /// <summary>
    /// 
    /// </summary>
    public class ParentWindow : Behavior<Window>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}
