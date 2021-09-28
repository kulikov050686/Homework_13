using Homework_13.Interfaces;
using System;
using System.Collections.Generic;

namespace Homework_13.Services
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон по работе с кредитными счетами
    /// </summary>
    public class CreditAccountDialog : IBankAccountDialogService<ICreditAccount>
    {
        public ICreditAccount CreateNewBankAccount()
        {
            throw new NotImplementedException();
        }

        public ICreditAccount EditBankAccountData(ICreditAccount bankAccount)
        {
            throw new NotImplementedException();
        }

        public ICreditAccount CombiningBankAccounts(IList<ICreditAccount> bankAccounts)
        {
            throw new NotImplementedException();
        }
    }
}
