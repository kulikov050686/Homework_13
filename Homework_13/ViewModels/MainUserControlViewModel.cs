using Homework_13.Commands;
using Homework_13.Enums;
using Homework_13.Interfaces;
using Homework_13.Models;
using Homework_13.Services;
using Microsoft.Extensions.DependencyInjection;
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

        private readonly DepartmentsManager _departmentsManager;
        private readonly BankCustomersManager _bankCustomersManager;
        private readonly ProcessingOfDepositoryAccounts _processingOfDepositoryAccounts;        

        private BankCustomerDialog _bankCustomerDialog;              
        private Department _selectedDepartment;
        private BankCustomer _selectedBankCustomer;
        private DepositoryAccount _selectedDepositoryAccount;

        private BankCustomerInfoDialog BankCustomerInfoDialog => App.Host.Services.GetRequiredService<BankCustomerInfoDialog>();
        
        #endregion

        #region Открытые свойства

        /// <summary>
        /// Список всех департаментов банка
        /// </summary>
        public IList<IDepartment> Departments => _departmentsManager.Departments;

        /// <summary>
        /// Список всех клиентов банка
        /// </summary>
        public IList<IBankCustomer> BankCustomers => _bankCustomersManager.BankCustomers;
        
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
        /// Выбранный депозитарный счёт
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

                var bankCustomer = _bankCustomerDialog.Create(department.StatusDepartment);
                if (bankCustomer is null) return;

                _bankCustomersManager.Create(bankCustomer, department);
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
                _bankCustomersManager.Delete(bankCustomer, department);
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

                var tempBankCustomer = _bankCustomerDialog.Edit(bankCustomer);
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
                if(obj is BankCustomer bankCustomer)
                    _processingOfDepositoryAccounts.OpenAccount(bankCustomer);                
            }, (obj) => obj is BankCustomer);
        }

        #endregion

        #region Команда удаления депозитарного счёта

        private ICommand _deleteDepositoryAccount = default!;
        public ICommand DeleteDepositoryAccount
        {
            get => _deleteDepositoryAccount ??= new RelayCommand((obj) =>
            {
                _processingOfDepositoryAccounts.CloseAccount(SelectedBankCustomer);                
            }, (obj) => obj is DepositoryAccount);
        }

        #endregion

        #region Команда редактирования депозитарного счёта

        private ICommand _editDepositoryAccount = default!;
        public ICommand EditDepositoryAccount
        {
            get => _editDepositoryAccount ??= new RelayCommand((obj) =>
            {
                _processingOfDepositoryAccounts.EditAccount(SelectedBankCustomer);                
            }, (obj) => obj is DepositoryAccount);
        }

        #endregion

        #region Команда объединения депозитарных счетов

        private ICommand _combiningDepositoryAccounts = default!;
        public ICommand CombiningDepositoryAccounts
        {
            get => _combiningDepositoryAccounts ??= new RelayCommand((obj) =>
            {
                _processingOfDepositoryAccounts.CombiningAccounts(SelectedBankCustomer);                
            }, (obj) => obj is DepositoryAccount);
        }

        #endregion

        #region Команда пополнить депозитарный счёт

        private ICommand _transferToDepositoryAccount = default!;
        public ICommand TransferToDepositoryAccount
        {
            get => _transferToDepositoryAccount ??= new RelayCommand((obj) =>
            {
                _processingOfDepositoryAccounts.TransferToAccount(SelectedBankCustomer);
            }, (obj) => obj is DepositoryAccount);
        }

        #endregion

        #region Команда вывести средства со счета

        private ICommand _withdrawFromDepositoryAccount = default!;
        public ICommand WithdrawFromDepositoryAccount
        {
            get => _withdrawFromDepositoryAccount ??= new RelayCommand((obj) =>
            {
                _processingOfDepositoryAccounts.WithdrawFromAccount(SelectedBankCustomer);
            }, (obj) => obj is DepositoryAccount);
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainUserControlViewModel(BankCustomersManager bankCustomersManager,
                                        DepartmentsManager departmentsManager,
                                        BankCustomerDialog bankCustomerDialog,
                                        ProcessingOfDepositoryAccounts processingOfDepositoryAccounts)
        {
            _departmentsManager = departmentsManager;
            _bankCustomersManager = bankCustomersManager;
            _bankCustomerDialog = bankCustomerDialog;
            _processingOfDepositoryAccounts = processingOfDepositoryAccounts;

            _bankCustomersManager.ManagerEvent += BankCustomersManagerEvent;
            _processingOfDepositoryAccounts.ProcessingOfAccountsEvent += OnProcessingOfAccountsEvent;
            _processingOfDepositoryAccounts.StartCalculate();
        }

        private void BankCustomersManagerEvent(object sender, ManagerArgs args)
        {
            /// реализовать
            BankCustomerInfoDialog.Dialog((IBankCustomer)sender);
        }        

        private void OnProcessingOfAccountsEvent(object sender, ProcessingOfAccountsArgs args)
        {
            /// реализовать 
        }
    }
}
