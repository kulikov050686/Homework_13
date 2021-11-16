using Microsoft.Xaml.Behaviors;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace Homework_13.Behaviors
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowDisappearing : Behavior<Window>
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Closing += onWindowClosing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onWindowClosing(object sender, CancelEventArgs e)
        {
            Window window = sender as Window;
            window.Closing -= onWindowClosing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
            anim.Completed += (s, a) => window.Close();
            window.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Closing -= onWindowClosing;
        }
    }
}
