using Homework_13.Enums;
using Homework_13.Infrastructure;
using Homework_13.Interfaces;
using System;
using System.Collections.Generic;

namespace Homework_13.Services
{
    public class ProcessingOfCreditAccounts
    {
        #region Закрытые поля

        CreditAccountsManager _creditAccountsManager;
        CreditAccountDialog _creditAccountDialog;

        #endregion

        /// <summary>
        /// Событие возникающее при обработке счетов
        /// <summary>
        public event ProcessingOfAccountsEventHandler ProcessingOfAccountsEvent;

        /// <summary>
        /// Список всех кредитных счетов
        /// </summary>
        public IList<ICreditAccount> CreditAccounts => _creditAccountsManager.СreditAccounts;

        /// <summary>
        /// Открыть кредитный счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        public bool OpenAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            var creditAccount = _creditAccountDialog.Create();
            if (creditAccount is null) return false;

            var result = _creditAccountsManager.Create(creditAccount, bankCustomer);
            if(result) ProcessingOfAccountsEvent?.Invoke(this, ProcessingOfAccountsArgs.OPEN);

            return result;
        }

        /// <summary>
        /// Конструктор
        /// </summary>        
        public ProcessingOfCreditAccounts(CreditAccountsManager creditAccountsManager,
                                          CreditAccountDialog creditAccountDialog)
        {
            _creditAccountsManager = creditAccountsManager;
            _creditAccountDialog = creditAccountDialog;
        }
    }
}
