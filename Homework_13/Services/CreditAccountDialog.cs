using Homework_13.Interfaces;
using Homework_13.Models;
using Homework_13.Views;
using System;
using System.Collections.Generic;

namespace Homework_13.Services
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон по работе с кредитными счетами
    /// </summary>
    public class CreditAccountDialog : IBankAccountDialogService<ICreditAccount>
    {
        /// <summary>
        /// Создание нового кредитного счёта
        /// </summary>
        public ICreditAccount Create()
        {
            var dialog = new AddCreditAccountWindow();
            if (dialog.ShowDialog() != true) return null;

            return new CreditAccount(0, dialog.Amount, dialog.InterestRate, dialog.CreditTerm, dialog.SelectedCreditStatus);
        }

        /// <summary>
        /// Редактировать данные кредитного счёта
        /// </summary>
        /// <param name="bankAccount"> Кредитный счёт </param>        
        public ICreditAccount Edit(ICreditAccount bankAccount)
        {
            if (bankAccount is null)
                throw new ArgumentNullException("Депозитарный счёт не может быть null!!!");
            
            var dialog = new AddCreditAccountWindow();
            if (dialog.ShowDialog() != true) return null;
            dialog.Amount = bankAccount.Amount;
            dialog.InterestRate = bankAccount.InterestRate;
            dialog.CreditTerm = bankAccount.CreditTerm;
            dialog.SelectedCreditStatus = bankAccount.CreditStatus;

            if (dialog.ShowDialog() != true) return null;

            return new CreditAccount(bankAccount.Id, dialog.Amount, dialog.InterestRate, dialog.CreditTerm, dialog.SelectedCreditStatus);
        }

        /// <summary>
        /// Выбрать кредитный счёт из списка кредитных счетов
        /// </summary>
        /// <param name="entities"> Список кредитных счетов </param>        
        public ICreditAccount Selected(IList<ICreditAccount> bankAccounts)
        {
            if (bankAccounts is null)
                throw new ArgumentNullException("Список счетов не может быть null!!!");

            var dialog = new SelectedBankAccountWindow();
            dialog.BankAccounts = bankAccounts;
            if (dialog.ShowDialog() != true) return null;

            return dialog.SelectedBankAccount as ICreditAccount;
        }
    }
}
