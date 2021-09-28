using Homework_13.Interfaces;
using System;
using System.Collections.Generic;

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
        public IList<ICreditAccount> СreditAccounts => _creditAccounts.GetAll();

        /// <summary>
        /// Обновление данных кредитного счёта клиента банка и сохранение в репозитории
        /// </summary>
        /// <param name="creditAccount"> Креитный счёт </param>
        public void Update(ICreditAccount creditAccount)
        {
            _creditAccounts.Update(creditAccount.Id, creditAccount);
        }

        /// <summary>
        /// Добавить новый кредитный счёт
        /// </summary>
        /// <param name="creditAccount"> Кредитный счёт </param>
        /// <param name="bankCustomer"> Клиент банка </param>        
        public bool CreateNewCreditAccount(ICreditAccount creditAccount,
                                           IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Клиент банка не может быть null!!!");
            if (creditAccount is null)
                throw new ArgumentNullException(nameof(creditAccount), "Счёт не может быть null!!!");

            var selectedBankCustomer = _bankCustomers.Get(bankCustomer.Id);
            if (selectedBankCustomer is null) return false;

            _creditAccounts.Add(creditAccount);
            bankCustomer.CreditAccounts.Add(creditAccount);

            return true;
        }

        /// <summary>
        /// Удалить кредитный счёт
        /// </summary>
        /// <param name="creditAccount"> Кредитный счёт </param>
        /// <param name="bankCustomer"> Клиент банка </param>        
        public bool DeleteCreditAccount(ICreditAccount creditAccount,
                                        IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Клиент банка не может быть null!!!");
            if (creditAccount is null)
                throw new ArgumentNullException(nameof(creditAccount), "Счёт не может быть null!!!");

            var selectedBankCustomer = _bankCustomers.Get(bankCustomer.Id);
            if (selectedBankCustomer is null) return false;

            if(bankCustomer.CreditAccounts.Remove(creditAccount))
            {
                _creditAccounts.Remove(creditAccount);
                return true;
            }

            return false;
        }

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
