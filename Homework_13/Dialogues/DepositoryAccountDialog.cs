using Homework_13.Interfaces;
using Homework_13.Models;
using Homework_13.Views;
using System;
using System.Collections.Generic;

namespace Homework_13.Dialogues
{
    /// <summary>
    /// Cервис диалоговых окон по работе с депозитарными счетами
    /// </summary>
    public class DepositoryAccountDialog : IDialogService<IDepositoryAccount>
    {
        /// <summary>
        /// Создание нового депозитарного счёта
        /// </summary>        
        public IDepositoryAccount Create()
        {
            var dialog = new AddDepositoryAccountWindow();
            dialog.TextOfInputButton = "Добавить";
            if (dialog.ShowDialog() != true) return null;

            return new DepositoryAccount(0, dialog.Amount, dialog.InterestRate, dialog.SelectedDepositStatus);
        }

        /// <summary>
        /// Редактировать данные депозитарного счёта
        /// </summary>
        /// <param name="bankAccount"> Депозитарный счёт </param>        
        public IDepositoryAccount Edit(IDepositoryAccount bankAccount)
        {
            if (bankAccount is null)
                throw new ArgumentNullException("Депозитарный счёт не может быть null!!!");

            var dialog = new AddDepositoryAccountWindow();
            dialog.TextOfInputButton = "Применить";
            dialog.AmountVisibility = System.Windows.Visibility.Collapsed;
            dialog.InterestRate = bankAccount.InterestRate;
            dialog.SelectedDepositStatus = bankAccount.DepositStatus;

            if (dialog.ShowDialog() != true) return null;

            return new DepositoryAccount(bankAccount.Id, dialog.Amount, dialog.InterestRate, dialog.SelectedDepositStatus);
        }

        /// <summary>
        /// Выбрать дипозитарный счёт из списка депозитарных счетов
        /// </summary>
        /// <param name="bankAccounts"> Список депозитарных счетов </param>        
        public IDepositoryAccount Selected(IList<IDepositoryAccount> bankAccounts)
        {
            if (bankAccounts is null)
                throw new ArgumentNullException("Список счетов не может быть null!!!");

            var dialog = new SelectedBankAccountWindow();
            dialog.BankAccounts = bankAccounts;
            if (dialog.ShowDialog() != true) return null;

            return dialog.SelectedBankAccount as IDepositoryAccount;
        }

        /// <summary>
        /// Выбрать два дипозитарных счёта из списка депозитарных счетов
        /// </summary>
        /// <param name="bankAccounts"> Список депозитарных счетов </param>
        /// <param name="bankAccounts1"> Депозитарный счёт 1 </param>
        /// <param name="bankAccounts2"> Депозитарный счёт 2 </param>
        public void SelectTwoBankAccounts(IList<IDepositoryAccount> bankAccounts, out IDepositoryAccount bankAccounts1, out IDepositoryAccount bankAccounts2)
        {
            if (bankAccounts is null)
                throw new ArgumentNullException("Список счетов не может быть null!!!");

            bankAccounts1 = null;
            bankAccounts2 = null;

            var dialog = new SelectTwoBankAccountsWindow();
            dialog.BankAccounts = bankAccounts;
            if (dialog.ShowDialog() != true) return;

            bankAccounts1 = dialog.SelectedBankAccount1 as DepositoryAccount;
            bankAccounts2 = dialog.SelectedBankAccount2 as DepositoryAccount;
        }

        /// <summary>
        /// Изменить сумму банковского счета
        /// </summary>                
        public double? ChangeAmountOfBankAccount()
        {
            var dialog = new AddDepositoryAccountWindow();
            dialog.TextOfInputButton = "Применить";
            dialog.InterestRateVisibility = System.Windows.Visibility.Collapsed;
            dialog.DepositStatusVisibility = System.Windows.Visibility.Collapsed;

            if (dialog.ShowDialog() != true) return null;

            return dialog.Amount;
        }        
    }
}
