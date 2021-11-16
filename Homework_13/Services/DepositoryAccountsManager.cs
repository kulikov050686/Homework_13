using System.Collections.Generic;
using System;
using Homework_13.Interfaces;

namespace Homework_13.Services
{
    /// <summary>
    /// Менеджер депозитарного счёта
    /// </summary>
    public class DepositoryAccountsManager
    {
        #region Закрытые поля

        DepositoryAccountRepository _depositoryAccountRepository;
        BankCustomersManager _bankCustomersManager;

        #endregion

        /// <summary>
        /// Получить список всех депозитарных счетов клиентов банка
        /// </summary>
        public IList<IDepositoryAccount> DepositoryAccounts => _depositoryAccountRepository.GetAll();

        /// <summary>
        /// Обновление данных депозитарного счёта клиента банка и сохранение в репозитории
        /// </summary>
        /// <param name="depositoryAccount"> Депозитарный счёт </param>
        public void Update(IDepositoryAccount depositoryAccount)
        {
            _depositoryAccountRepository.Update(depositoryAccount.Id, depositoryAccount);
        }

        /// <summary>
        /// Добавить новый депозотарный счёт
        /// </summary>
        /// <param name="depositoryAccount"> Депозитарный счёт </param>
        /// <param name="bankCustomer"> Клиент банка </param>
        public bool Create(IDepositoryAccount depositoryAccount,
                           IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Клиент банка не может быть null!!!");
            if (depositoryAccount is null)
                throw new ArgumentNullException(nameof(depositoryAccount), "Счёт не может быть null!!!");

            var selectedBankCustomer = _bankCustomersManager.Get(bankCustomer.Id);
            if (selectedBankCustomer is null) return false;

            bankCustomer.DepositoryAccounts.Add(depositoryAccount);
            _depositoryAccountRepository.Add(depositoryAccount);

            return true;
        }

        /// <summary>
        /// Удалить депозотарный счёт
        /// </summary>
        /// <param name="depositoryAccount"> Депозитарный счёт </param>
        /// <param name="bankCustomer"> Клиент банка </param>
        public bool Delete(IDepositoryAccount depositoryAccount,
                           IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Клиент банка не может быть null!!!");
            if (depositoryAccount is null)
                throw new ArgumentNullException(nameof(depositoryAccount), "Счёт не может быть null!!!");

            var selectedBankCustomer = _bankCustomersManager.Get(bankCustomer.Id);
            if (selectedBankCustomer is null) return false;

            if(bankCustomer.DepositoryAccounts.Remove(depositoryAccount))
            {
                _depositoryAccountRepository.Remove(depositoryAccount);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получить депозитарный счёт по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор </param>        
        public IDepositoryAccount Get(int id) => _depositoryAccountRepository.Get(id);

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="depositoryAccountRepository"> Хранилище депозитарных счетов клиентов банка </param>
        /// <param name="bankCustomersManager"> Хранилище клиентов банка </param>
        public DepositoryAccountsManager(DepositoryAccountRepository depositoryAccountRepository,
                                         BankCustomersManager bankCustomersManager)
        {
            _bankCustomersManager = bankCustomersManager;
            _depositoryAccountRepository = depositoryAccountRepository;
        }
    }
}
