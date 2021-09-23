using Homework_13.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_13.Services
{
    /// <summary>
    /// Менеджер кредитного счёта
    /// </summary>
    public class CreditAccountsManager
    {
        #region Закрытые поля

        CreditAccountRepository _creditAccounts;
        BankCustomerRepository _bankCustomers;

        #endregion

        /// <summary>
        /// Получить список всех крединных счетов клиентов банка
        /// </summary>
        public IList<ICreditAccount> creditAccounts => _creditAccounts.GetAll();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="creditAccountRepository"> Хранилище кредитных счетов клиентов банка </param>
        /// <param name="bankCustomerRepository"> Хранилище клиентов банка </param>
        public CreditAccountsManager(CreditAccountRepository creditAccountRepository,
                                     BankCustomerRepository bankCustomerRepository)
        {
            _creditAccounts = creditAccountRepository;
            _bankCustomers = bankCustomerRepository;
        }
    }
}
