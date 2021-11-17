using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Homework_13.Views
{
    public partial class InfoWindow : Window
    {
        #region Цвет фона

        public static readonly DependencyProperty ColorBackgroundProperty =
            DependencyProperty.Register(nameof(ColorBackground),
                                        typeof(Brush),
                                        typeof(InfoWindow),
                                        new PropertyMetadata(Brushes.Yellow));

        /// <summary>
        /// Цвет фона
        /// </summary>
        [Description("Цвет фона")]
        public Brush ColorBackground
        {
            get => (Brush)GetValue(ColorBackgroundProperty);
            set => SetValue(ColorBackgroundProperty, value);
        }

        #endregion

        #region Текст сообщения

        public static readonly DependencyProperty MessageTextProperty =
            DependencyProperty.Register(nameof(MessageText),
                                        typeof(string),
                                        typeof(InfoWindow),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Description("Текст сообщения")]
        public string MessageText
        {
            get => (string)GetValue(MessageTextProperty);
            set => SetValue(MessageTextProperty, value);
        }

        #endregion

        public InfoWindow() => InitializeComponent();              
    }
}
