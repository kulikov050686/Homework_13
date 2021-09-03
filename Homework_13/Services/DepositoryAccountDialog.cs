using Homework_13.Interfaces;
using Homework_13.Models;
using Homework_13.Views;
using System;
using System.Collections.Generic;

namespace Homework_13.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class DepositoryAccountDialog : IBankAccountDialogService<DepositoryAccount>
    {
        /// <summary>
        /// 
        /// </summary>        
        public DepositoryAccount CreateNewBankAccount()
        {
            var dialog = new AddDepositoryAccountWindow();
            if (dialog.ShowDialog() != true) return null;

            var depositoryAccount = new DepositoryAccount(0, dialog.SelectedDepositStatus);
            depositoryAccount.Amount = dialog.Amount;
            depositoryAccount.InterestRate = dialog.InterestRate;

            return depositoryAccount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankAccount"></param>        
        public DepositoryAccount EditBankAccountData(DepositoryAccount bankAccount)
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
        /// 
        /// </summary>
        /// <param name="bankAccounts"></param>        
        public DepositoryAccount CombiningBankAccounts(IEnumerable<DepositoryAccount> bankAccounts)
        {
            throw new NotImplementedException();
        }
    }
}
