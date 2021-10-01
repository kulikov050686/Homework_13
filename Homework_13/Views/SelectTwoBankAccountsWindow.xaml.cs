using System.Collections;
using System.ComponentModel;
using System.Windows;

namespace Homework_13.Views
{    
    public partial class SelectTwoBankAccountsWindow : Window
    {
        #region Список счетов

        public static readonly DependencyProperty BankAccountsProperty =
            DependencyProperty.Register(nameof(BankAccounts),
                                        typeof(IEnumerable),
                                        typeof(SelectTwoBankAccountsWindow),
                                        new PropertyMetadata(default(IEnumerable)));

        /// <summary>
        /// Список счетов
        /// </summary>
        [Description("Список счетов")]
        public IEnumerable BankAccounts
        {
            get => (IEnumerable)GetValue(BankAccountsProperty);
            set => SetValue(BankAccountsProperty, value);
        }

        #endregion
        
        #region Выбранный счёт 1

        public static readonly DependencyProperty SelectedBankAccount1Property =
            DependencyProperty.Register(nameof(SelectedBankAccount1),
                                        typeof(object),
                                        typeof(SelectTwoBankAccountsWindow),
                                        new PropertyMetadata(default(object)));

        /// <summary>
        /// Выбранный счёт 1
        /// </summary>
        [Description("Выбранный счёт 1")]
        public object SelectedBankAccount1
        {
            get => GetValue(SelectedBankAccount1Property);
            set => SetValue(SelectedBankAccount1Property, value);
        }

        #endregion

        #region Выбранный счёт 2

        public static readonly DependencyProperty SelectedBankAccount2Property =
            DependencyProperty.Register(nameof(SelectedBankAccount2),
                                        typeof(object),
                                        typeof(SelectTwoBankAccountsWindow),
                                        new PropertyMetadata(default(object)));

        /// <summary>
        /// Выбранный счёт 2
        /// </summary>
        [Description("Выбранный счёт 1")]
        public object SelectedBankAccount2
        {
            get => GetValue(SelectedBankAccount2Property);
            set => SetValue(SelectedBankAccount2Property, value);
        }

        #endregion

        public SelectTwoBankAccountsWindow() => InitializeComponent();        
    }
}
