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

            return new DepositoryAccount(0, dialog.Amount, dialog.InterestRate, dialog.SelectedDepositStatus);
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

            return new DepositoryAccount(bankAccount.Id, dialog.Amount, dialog.InterestRate, dialog.SelectedDepositStatus);
        }

        /// <summary>
        /// Выбрать дипозитарный счёт из списка депозитарных счетов
        /// </summary>
        /// <param name="bankAccounts"> Список депозитарных счетов </param>        
        public IDepositoryAccount SelectedBankAccounts(IList<IDepositoryAccount> bankAccounts)
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
