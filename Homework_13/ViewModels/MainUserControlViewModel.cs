﻿using Homework_13.Models;
using Homework_13.Services;
using System.Collections.Generic;

namespace Homework_13.ViewModels
{
    /// <summary>
    /// Модель-Представление главного контрола
    /// </summary>
    public class MainUserControlViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        private readonly BankCustomersManager _bankCustomersManager;
        private readonly DepositoryAccountsManager _depositoryAccountsManager;
        private Department _selectedDepartment;
        private BankCustomer _selectedBankCustomer;
        private DepositoryAccount _selectedDepositoryAccount;

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Список всех департаментов банка
        /// </summary>
        public IEnumerable<Department> Departments => _bankCustomersManager.Departments;

        /// <summary>
        /// Список всех клиентов банка
        /// </summary>
        public IEnumerable<BankCustomer> BankCustomers => _bankCustomersManager.BankCustomers;

        /// <summary>
        /// Список всех депозитарных счетов
        /// </summary>
        public IEnumerable<DepositoryAccount> DepositoryAccounts => _depositoryAccountsManager.DepositoryAccounts;

        /// <summary>
        /// Выбранный департамент
        /// </summary>
        public Department SelectedDepartment
        {
            get => _selectedDepartment;
            set => Set(ref _selectedDepartment, value);
        }

        /// <summary>
        /// Выбранный клиент
        /// </summary>
        public BankCustomer SelectedBankCustomer
        {
            get => _selectedBankCustomer;
            set => Set(ref _selectedBankCustomer, value);
        }

        /// <summary>
        /// Выбранный дпозитарный счёт
        /// </summary>
        public DepositoryAccount SelectedDepositoryAccount
        {
            get => _selectedDepositoryAccount;
            set => Set(ref _selectedDepositoryAccount, value);
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainUserControlViewModel(BankCustomersManager bankCustomersManager,
                                        DepositoryAccountsManager depositoryAccountsManager)
        {
            _bankCustomersManager = bankCustomersManager;
            _depositoryAccountsManager = depositoryAccountsManager;
        }
    }
}
