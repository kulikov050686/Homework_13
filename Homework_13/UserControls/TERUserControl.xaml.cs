using Homework_13.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Homework_13.UserControls
{    
    public partial class TERUserControl : UserControl
    {
        #region Телефон

        public static readonly DependencyProperty PhoneNumberUCProperty =
            DependencyProperty.Register(nameof(PhoneNumberUC),
                                        typeof(string),
                                        typeof(TERUserControl),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Телефон
        /// </summary>
        [Description("Телефон")]
        public string PhoneNumberUC
        {
            get => (string)GetValue(PhoneNumberUCProperty);
            set => SetValue(PhoneNumberUCProperty, value);
        }

        #endregion

        #region Электронный адрес

        public static readonly DependencyProperty EmailUCProperty =
            DependencyProperty.Register(nameof(EmailUC),
                                        typeof(string),
                                        typeof(TERUserControl),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Электронный адрес
        /// </summary>
        [Description("Электронный адрес")]
        public string EmailUC
        {
            get => (string)GetValue(EmailUCProperty);
            set => SetValue(EmailUCProperty, value);
        }

        #endregion

        #region Рейтинг

        public static readonly DependencyProperty ReliabilityUCProperty =
            DependencyProperty.Register(nameof(ReliabilityUC),
                                        typeof(Reliability),
                                        typeof(TERUserControl),
                                        new PropertyMetadata(default(Reliability)));

        /// <summary>
        /// Рейтинг
        /// </summary>
        [Description("Рейтинг")]
        public Reliability ReliabilityUC
        {
            get => (Reliability)GetValue(ReliabilityUCProperty);
            set => SetValue(ReliabilityUCProperty, value);
        }

        #endregion

        #region Лист надёжности

        /// <summary>
        /// Лист надёжности
        /// </summary>
        [Description("Лист надёжности")]
        public List<string> ReliabilityListUC { get; set; } = new List<string> { "Низкая",
                                                                                 "Средняя",
                                                                                 "Высокая" };

        #endregion

        public TERUserControl() => InitializeComponent();       
    }
}
