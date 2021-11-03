using Homework_13.Commands;
using Homework_13.Interfaces;
using Homework_13.Services;
using System.Collections.Generic;
using System.Linq;
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
        private FileDialog _fileDialog;
        private DepartmentRepository _departmentRepository;
        private BankCustomerRepository _bankCustomerRepository;
        private DepositoryAccountRepository _depositoryAccountRepository;
        private CreditAccountRepository _creditAccountRepository;

        #endregion

        /// <summary>
        /// Список всех департаментов банка
        /// </summary>
        public IList<IDepartment> Departments { get; set; }

        /// <summary>
        /// Список всех клиентов банка
        /// </summary>
        public IList<IBankCustomer> BankCustomers { get; set; }

        /// <summary>
        /// Список всех депозитарных счетов
        /// </summary>
        public IList<IDepositoryAccount> DepositoryAccounts { get; set; }

        /// <summary>
        /// Список всех кредитных счетов
        /// </summary>
        public IList<ICreditAccount> CreditAccounts { get; set; }

        #region Команда сохранить в файл

        private ICommand _saveToFile = default!;
        public ICommand SaveToFile
        {
            get => _saveToFile ??= new RelayCommand((obj) =>
            {                
                _fileDialog.SaveFileDialog(Departments);
            }, (obj) => _mainUserControlViewModel.Departments != null);
        }

        #endregion

        #region Команда получить данные из файла

        private ICommand _openFile = default!;
        public ICommand OpenFile
        {
            get => _openFile ??= new RelayCommand((obj) => 
            {
                var departments = _fileDialog.OpenFileDialog();

                if (departments != null)
                {
                    Departments = departments;
                    _departmentRepository.SetAll(Departments);

                    var bankCustomers = Departments.SelectMany(d => d.BankCustomers).ToList();

                    if(bankCustomers != null)
                    {
                        BankCustomers = bankCustomers;
                        _bankCustomerRepository.SetAll(BankCustomers);

                        var depositoryAccounts = BankCustomers.SelectMany(d => d.DepositoryAccounts).ToList();

                        if (depositoryAccounts != null)
                        {
                            DepositoryAccounts = depositoryAccounts;
                            _depositoryAccountRepository.SetAll(DepositoryAccounts);
                        }

                        var creditAccounts = BankCustomers.SelectMany(d => d.CreditAccounts).ToList();

                        if(creditAccounts != null)
                        {
                            CreditAccounts = creditAccounts;
                            _creditAccountRepository.SetAll(CreditAccounts);
                        }
                    }             
                }               
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
        public MainMenuUserControlViewModel(MainUserControlViewModel mainUserControlViewModel,
                                            FileDialog fileDialog,
                                            DepartmentRepository departmentRepository,
                                            BankCustomerRepository bankCustomerRepository,
                                            DepositoryAccountRepository depositoryAccountRepository,
                                            CreditAccountRepository creditAccountRepository)
        {
            _mainUserControlViewModel = mainUserControlViewModel;
            _fileDialog = fileDialog;
            _departmentRepository = departmentRepository;
            _bankCustomerRepository = bankCustomerRepository;
            _depositoryAccountRepository = depositoryAccountRepository;
            _creditAccountRepository = creditAccountRepository;

            Departments = _mainUserControlViewModel.Departments;            
        }
    }
}
