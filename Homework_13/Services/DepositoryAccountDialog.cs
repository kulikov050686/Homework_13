using Homework_13.Interfaces;
using Homework_13.Models;
using Homework_13.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_13.Services
{
    public class DepositoryAccountDialog : IBankAccountDialogService<DepositoryAccount>
    {
        public DepositoryAccount CreateNewBankAccount()
        {
            var dialog = new AddDepositoryAccountWindow();

            if (dialog.ShowDialog() != true) return null;

            return null;
        }

        public DepositoryAccount EditBankAccountData(DepositoryAccount bankAccount)
        {
            throw new NotImplementedException();
        }

        public DepositoryAccount CombiningBankAccounts(IEnumerable<DepositoryAccount> bankAccounts)
        {
            throw new NotImplementedException();
        }
    }
}
