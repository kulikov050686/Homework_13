using Homework_13.Interfaces;
using Homework_13.Models;
using Homework_13.Views;
using System;
using System.Collections.Generic;

namespace Homework_13.Services
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон по работе с депозитарными счетами
    /// </summary>
    public class DepositoryAccountDialog : IBankAccountDialogService<IDepositoryAccount>
    {
        /// <summary>
        /// Создание нового депозитарного счёта
        /// </summary>        
        public IDepositoryAccount CreateNewBankAccount()
        {
            var dialog = new AddDepositoryAccountWindow();
            if (dialog.ShowDialog() != true) return null;

            var depositoryAccount = new DepositoryAccount(0, dialog.SelectedDepositStatus);
            depositoryAccount.Amount = dialog.Amount;
            depositoryAccount.InterestRate = dialog.InterestRate;

            return depositoryAccount;
        }

        /// <summary>
        /// Редактировать данные депозитарного счёта
        /// </summary>
        /// <param name="bankAccount"> Депозитарный счёт </param>        
        public IDepositoryAccount EditBankAccountData(IDepositoryAccount bankAccount)
        {
            if (bankAccount is null)
                throw new ArgumentNullException("Депозитарный счёт не может быть null!!!");

            var dialog = new AddDepositoryAccountWindow();
            dialog.Amount = bankAccount.Amount;
            dialog.InterestRate = bankAccount.InterestRate;
            dialog.SelectedDepositStatus = bankAccount.DepositStatus;

            if (dialog.ShowDialog() != true) return null;

            var tempDepositoryAccount = new DepositoryAccount(bankAccount.Id, bankAccount.DepositStatus);
            tempDepositoryAccount.Amount = dialog.Amount;
            tempDepositoryAccount.InterestRate = dialog.InterestRate;
            tempDepositoryAccount.DepositStatus = dialog.SelectedDepositStatus;

            return tempDepositoryAccount;
        }

        /// <summary>
        /// Объединить депозитарные счета в один счёт
        /// </summary>
        /// <param name="bankAccounts"> Список депозитарных счетов </param>        
        public IDepositoryAccount CombiningBankAccounts(IList<IDepositoryAccount> bankAccounts)
        {
            if (bankAccounts is null)
                throw new ArgumentNullException("Список счетов не может быть null!!!");

            var dialog = new SelectedBankAccountWindow();
            dialog.BankAccounts = bankAccounts;
            if (dialog.ShowDialog() != true) return null;

            return dialog.SelectedBankAccount as DepositoryAccount;
        }
    }
}
