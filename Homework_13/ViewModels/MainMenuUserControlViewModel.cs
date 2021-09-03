using Homework_13.Commands;
using Homework_13.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Homework_13.ViewModels
{
    /// <summary>
    /// Модель-Представление контрола главного меню
    /// </summary>
    public class MainMenuUserControlViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        private MainUserControlViewModel _mainUserControlViewModel;

        #endregion

        /// <summary>
        /// Список всех департаментов банка
        /// </summary>
        public IEnumerable<Department> Departments => _mainUserControlViewModel.Departments;

        #region Команда сохранить в файл

        private ICommand _saveToFile = default!;
        public ICommand SaveToFile
        {
            get => _saveToFile ??= new RelayCommand((obj) =>
            {
                /// Сохранение в файл департаментов
            });
        }

        #endregion

        #region Команда создания нового клиента банка

        private ICommand _createNewBankCustomer = default!;
        public ICommand CreateNewBankCustomer
        {
            get => _createNewBankCustomer ??= new RelayCommand((obj) =>
            {
                _mainUserControlViewModel.CreateNewBankCustomer.Execute(_mainUserControlViewModel.SelectedDepartment);
            }, (obj) => _mainUserControlViewModel.SelectedDepartment != null);
        }

        #endregion

        #region Команда удаления клиента банка

        private ICommand _deleteBankCustomer = default!;
        public ICommand DeleteBankCustomer
        {
            get => _deleteBankCustomer ??= new RelayCommand((obj) =>
            {
                _mainUserControlViewModel.DeleteBankCustomer.Execute(_mainUserControlViewModel.SelectedBankCustomer);
            }, (obj) => _mainUserControlViewModel.SelectedBankCustomer != null);
        }

        #endregion

        #region Команда редактирования данных клиента банка

        private ICommand _editDataBankCustomer = default!;
        public ICommand EditDataBankCustomer
        {
            get => _editDataBankCustomer ??= new RelayCommand((obj) =>
            {
                _mainUserControlViewModel.EditDataBankCustomer.Execute(_mainUserControlViewModel.SelectedBankCustomer);
            }, (obj) => _mainUserControlViewModel.SelectedBankCustomer != null);
        }

        #endregion

        #region Команда создание нового депозитарного счёта

        private ICommand _createNewDepositoryAccount = default!;
        public ICommand CreateNewDepositoryAccount
        {
            get => _createNewDepositoryAccount ??= new RelayCommand((obj) =>
            {
                _mainUserControlViewModel.CreateNewDepositoryAccount.Execute(_mainUserControlViewModel.SelectedBankCustomer);
            }, (obj) => _mainUserControlViewModel.SelectedBankCustomer != null);
        }

        #endregion

        #region Команда удаления депозитарного счёта

        private ICommand _deleteDepositoryAccount = default!;
        public ICommand DeleteDepositoryAccount
        {
            get => _deleteDepositoryAccount ??= new RelayCommand((obj) =>
            {
                _mainUserControlViewModel.DeleteDepositoryAccount.Execute(_mainUserControlViewModel.SelectedDepositoryAccount);
            }, (obj) => _mainUserControlViewModel.SelectedDepositoryAccount != null);
        }

        #endregion

        #region Команда редактирования депозитарного счёта

        private ICommand _editDepositoryAccount = default!;
        public ICommand EditDepositoryAccount
        {
            get => _editDepositoryAccount ??= new RelayCommand((obj) =>
            {
                _mainUserControlViewModel.EditDepositoryAccount.Execute(_mainUserControlViewModel.SelectedDepositoryAccount);
            }, (obj) => _mainUserControlViewModel.SelectedDepositoryAccount != null);
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>        
        public MainMenuUserControlViewModel(MainUserControlViewModel mainUserControlViewModel)
        {
            _mainUserControlViewModel = mainUserControlViewModel;
        }
    }
}
