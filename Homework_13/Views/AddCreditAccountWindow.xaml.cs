using Homework_13.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Homework_13.Views
{    
    public partial class AddCreditAccountWindow : Window
    {
        #region Сумма

        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register(nameof(Amount),
                                        typeof(double?),
                                        typeof(AddCreditAccountWindow),
                                        new PropertyMetadata(default(double?)));

        /// <summary>
        /// Сумма
        /// </summary>
        [Description("Сумма")]
        public double? Amount
        {
            get => (double?)GetValue(AmountProperty);
            set => SetValue(AmountProperty, value);
        }

        #endregion

        #region Процентная ставка

        public static readonly DependencyProperty InterestRateProperty =
            DependencyProperty.Register(nameof(InterestRate),
                                        typeof(double?),
                                        typeof(AddCreditAccountWindow),
                                        new PropertyMetadata(default(double?)));

        /// <summary>
        /// Процентная ставка
        /// </summary>
        [Description("Процентная ставка")]
        public double? InterestRate
        {
            get => (double?)GetValue(InterestRateProperty);
            set => SetValue(InterestRateProperty, value);
        }

        #endregion

        #region Срок кредитования

        public static readonly DependencyProperty CreditTermProperty =
            DependencyProperty.Register(nameof(CreditTerm),
                                        typeof(byte?),
                                        typeof(AddCreditAccountWindow),
                                        new PropertyMetadata(default(byte?)));

        /// <summary>
        /// Срок кредитования
        /// </summary>
        [Description("Срок кредитования")]
        public byte? CreditTerm
        {
            get => (byte?)GetValue(CreditTermProperty);
            set => SetValue(CreditTermProperty, value);
        }

        #endregion

        #region Лист статусов кредита

        public List<string> CreditStatusList { get; set; } = new List<string> { "Ануитет", "Дифференцированный" };

        #endregion

        #region Выбор статуса депозита

        public static readonly DependencyProperty SelectedCreditStatusProperty =
            DependencyProperty.Register(nameof(SelectedCreditStatus),
                                        typeof(CreditStatus),
                                        typeof(AddCreditAccountWindow),
                                        new PropertyMetadata(default(CreditStatus)));

        /// <summary>
        /// Выбор статуса кредита
        /// </summary>
        [Description("Выбор статуса кредита")]
        public CreditStatus SelectedCreditStatus
        {
            get => (CreditStatus)GetValue(SelectedCreditStatusProperty);
            set => SetValue(SelectedCreditStatusProperty, value);
        }

        #endregion

        public AddCreditAccountWindow() => InitializeComponent();        
    }
}
