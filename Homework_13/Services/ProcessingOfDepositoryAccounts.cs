using Homework_13.Enums;
using Homework_13.Infrastructure;
using Homework_13.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace Homework_13.Services
{
    public class ProcessingOfDepositoryAccounts
    {
        #region Закрытые поля

        DepositoryAccountsManager _depositoryAccountsManager;
        DepositoryAccountDialog _depositoryAccountDialog;
        DispatcherTimer _timer;
        byte _k = 1;

        #endregion

        /// <summary>
        /// Событие возникающее при обработке счетов
        public event ProcessingOfAccountsEventHandler ProcessingOfAccountsEvent;

        /// <summary>
        /// Список всех депозитарных счетов
        /// </summary>
        public IList<IDepositoryAccount> DepositoryAccounts => _depositoryAccountsManager.DepositoryAccounts;

        /// <summary>
        /// Закрыть депозитарный счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        public bool CloseAccount(IBankCustomer bankCustomer)
        {
            if(bankCustomer is null)
                throw new ArgumentNullException();

            var account = _depositoryAccountDialog.SelectedBankAccounts(bankCustomer.DepositoryAccounts);
            if (account is null) return false;

            return _depositoryAccountsManager.DeleteDepositoryAccount(account, bankCustomer);
        }

        /// <summary>
        /// Объединить депозитарные счета
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>             
        public bool CombiningAccounts(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            IDepositoryAccount account1;
            IDepositoryAccount account2;

            _depositoryAccountDialog.SelectTwoBankAccounts(bankCustomer.DepositoryAccounts, out account1, out account2);
            if (account1 is null || account2 is null) return false;

            if (account1.Blocking || account2.Blocking)
            {
                MessageBox.Show("Счёт заблокирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return _depositoryAccountsManager.CombiningDepositoryAccounts(account1, account2, bankCustomer);            
        }

        /// <summary>
        /// Редактировать депозитарный счёт
        /// </summary>
        /// <param name="account"> Редактируемый депозитарный счёт </param>        
        public bool EditAccount(IBankCustomer bankCustomer)
        {
            if(bankCustomer is null)
                throw new ArgumentNullException();

            var account = _depositoryAccountDialog.SelectedBankAccounts(bankCustomer.DepositoryAccounts);
            if (account is null) return false;

            if (account.Blocking)
            {
                MessageBox.Show("Счёт заблокирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var tempDepositoryAccount = _depositoryAccountDialog.EditBankAccountData(account);
            if (tempDepositoryAccount is null) return false;

            _depositoryAccountsManager.Update(tempDepositoryAccount);
            return true;
        }

        /// <summary>
        /// Открыть депозитарный счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        public bool OpenAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            var depositoryAccount = _depositoryAccountDialog.CreateNewBankAccount();
            if (depositoryAccount is null) return false;

            return _depositoryAccountsManager.CreateNewDepositoryAccount(depositoryAccount, bankCustomer);
        }

        /// <summary>
        /// Перевести на счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        public bool TransferToAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            var account = _depositoryAccountDialog.SelectedBankAccounts(bankCustomer.DepositoryAccounts);
            if (account is null) return false;

            if (account.Blocking)
            {
                MessageBox.Show("Счёт заблокирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var result = _depositoryAccountDialog.ChangeAmountOfBankAccount();
            if (result is null) return false;

            if (result < 0)
            {
                MessageBox.Show("Сумма не может быть меньше нуля!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            account.Amount += result;

            _depositoryAccountsManager.Update(account);
            return true;
        }

        /// <summary>
        /// Вывести средства со счета
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        public double? WithdrawFromAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            var account = _depositoryAccountDialog.SelectedBankAccounts(bankCustomer.DepositoryAccounts);
            if (account is null) return null;

            if (account.Blocking)
            {
                MessageBox.Show("Счёт заблокирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            var result = _depositoryAccountDialog.ChangeAmountOfBankAccount();
            if (result is null) return null;

            if (result < 0)
            {
                MessageBox.Show("Сумма не может быть меньше нуля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            result = Math.Round((double)result, 2, MidpointRounding.ToEven);

            if (result > account.Amount)
            {
                MessageBox.Show("Нехватает суммы на счёте!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }             
            
            account.Amount -= result;
            account.Amount = Math.Round((double)account.Amount, 2, MidpointRounding.AwayFromZero);
            _depositoryAccountsManager.Update(account);

            return result;
        }

        /// <summary>
        /// Начать расчёт по депозитарным счетам
        /// </summary>
        public void StartCalculate()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 2);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        /// <summary>
        /// Остановить расчёт по депозитарным счетам
        /// </summary>
        public void StopCalculate()
        {
            _timer.Stop();
            _timer.Tick -= _timer_Tick;
            _timer = null;
        }

        public ProcessingOfDepositoryAccounts(DepositoryAccountsManager depositoryAccountsManager,
                                              DepositoryAccountDialog depositoryAccountDialog)
        {
            _depositoryAccountsManager = depositoryAccountsManager;
            _depositoryAccountDialog = depositoryAccountDialog;
        }

        /// <summary>
        /// Обработчик события таймера
        /// </summary>        
        private void _timer_Tick(object sender, EventArgs e)
        {
            foreach (var item in DepositoryAccounts)
            {
                if(!item.Blocking)
                {
                    if ((item.DepositStatus == DepositStatus.WITHOUTCAPITALIZATION) && _k == 12)
                    {
                        item.Amount = Math.Round((double)(item.Amount * (1 + item.InterestRate / 100.0)), 2, MidpointRounding.AwayFromZero);
                    }

                    if (item.DepositStatus == DepositStatus.WITHCAPITALIZATION)
                    {
                        item.Amount = Math.Round((double)(item.Amount * (1 + item.InterestRate / 1200.0)), 2, MidpointRounding.AwayFromZero);
                    }
                }                               
            }

            if (_k == 12)
            {
                _k = 1;
            }
            else
            {
                _k++;
            }
        }

        /// <summary>
        /// Проверка блокировки счёта
        /// </summary>
        /// <param name="account"> Счёт </param>        
        private bool СheckingForBlocking(IBankAccount account)
        {
            if (account.Blocking)
            {                
                return true;
            }

            return false;
        }
    }
}
