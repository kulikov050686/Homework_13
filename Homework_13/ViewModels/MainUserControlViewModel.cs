﻿using Homework_13.Commands;
using Homework_13.Models;
using Homework_13.Services;
using System.Collections.Generic;
using System.Windows.Input;

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
        private BankCustomerDialog _bankCustomerDialog;
        private DepositoryAccountDialog _depositoryAccountDialog;
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

        #region Команда создания нового клиента банка

        private ICommand _createNewBankCustomer = default!;
        public ICommand CreateNewBankCustomer
        {
            get => _createNewBankCustomer ??= new RelayCommand((obj) =>
            {
                var department = (Department)obj;
                if (department is null) return;

                var bankCustomer = _bankCustomerDialog.CreateNewBankCustomer(department.StatusDepartment);
                if (bankCustomer is null) return;

                _bankCustomersManager.CreateNewBankCustomer(bankCustomer, department);
            }, (obj) => obj is Department);
        }

        #endregion

        #region Команда удаления клиента банка

        private ICommand _deleteBankCustomer = default!;
        public ICommand DeleteBankCustomer
        {
            get => _deleteBankCustomer ??= new RelayCommand((obj) =>
            {
                var department = SelectedDepartment;
                var bankCustomer = (BankCustomer)obj;

                if (department is null || bankCustomer is null) return;
                _bankCustomersManager.DeleteBankCustomer(bankCustomer, department);
            }, (obj) => obj is BankCustomer);
        }

        #endregion

        #region Команда редактирования данных клиента банка

        private ICommand _editDataBankCustomer = default!;
        public ICommand EditDataBankCustomer
        {
            get => _editDataBankCustomer ??= new RelayCommand((obj) =>
            {
                var bankCustomer = (BankCustomer)obj;
                if (bankCustomer is null) return;

                var tempBankCustomer = _bankCustomerDialog.EditBankCustomerData(bankCustomer);
                if (tempBankCustomer is null) return;

                _bankCustomersManager.Update(tempBankCustomer);
            }, (obj) => obj is BankCustomer);
        }

        #endregion

        #region Команда создание нового депозитарного счёта

        private ICommand _createNewDepositoryAccount = default!;
        public ICommand CreateNewDepositoryAccount
        {
            get => _createNewDepositoryAccount ??= new RelayCommand((obj) =>
            {
                var bankCustomer = (BankCustomer)obj;
                var depositoryAccount = _depositoryAccountDialog.CreateNewBankAccount();
                if (depositoryAccount is null) return;

                _depositoryAccountsManager.CreateNewDepositoryAccount(depositoryAccount, bankCustomer);
            }, (obj) => obj is BankCustomer);
        }

        #endregion

        #region Команда удаления депозитарного счёта

        private ICommand _deleteDepositoryAccount = default!;
        public ICommand DeleteDepositoryAccount
        {
            get => _deleteDepositoryAccount ??= new RelayCommand((obj) =>
            {
                var bankCustomer = SelectedBankCustomer;
                var depositoryAccount = (DepositoryAccount)obj;
                if (bankCustomer is null || depositoryAccount is null) return;

                _depositoryAccountsManager.DeleteDepositoryAccount(depositoryAccount, bankCustomer);
            }, (obj) => obj is DepositoryAccount);
        }

        #endregion

        #region Команда редактирования депозитарного счёта

        private ICommand _editDepositoryAccount = default!;
        public ICommand EditDepositoryAccount
        {
            get => _editDepositoryAccount ??= new RelayCommand((obj) =>
            {
                
            }, (obj) => obj is DepositoryAccount);
        }

        #endregion

        #region Команда объединения депозитарных счетов

        private ICommand _combiningDepositoryAccounts = default!;
        public ICommand CombiningDepositoryAccounts
        {
            get => _combiningDepositoryAccounts ??= new RelayCommand((obj) =>
            {
                
            }, (obj) => obj is DepositoryAccount);
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainUserControlViewModel(BankCustomersManager bankCustomersManager,
                                        DepositoryAccountsManager depositoryAccountsManager,
                                        BankCustomerDialog bankCustomerDialog, 
                                        DepositoryAccountDialog depositoryAccountDialog)
        {
            _bankCustomersManager = bankCustomersManager;
            _depositoryAccountsManager = depositoryAccountsManager;
            _bankCustomerDialog = bankCustomerDialog;
            _depositoryAccountDialog = depositoryAccountDialog;
        }
    }
}
