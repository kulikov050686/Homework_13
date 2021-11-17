using Homework_13.Dialogues;
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
        /// <summary>
        public event ProcessingOfAccountsEventHandler ProcessingOfAccountsEvent;

        /// <summary>
        /// Список всех депозитарных счетов
        /// </summary>
        public IList<IDepositoryAccount> DepositoryAccounts => _depositoryAccountsManager.DepositoryAccounts;

        /// <summary>
        /// Открыть депозитарный счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        public bool OpenAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            var depositoryAccount = _depositoryAccountDialog.Create();
            if (depositoryAccount is null) return false;

            var result = _depositoryAccountsManager.Create(depositoryAccount, bankCustomer);

            if (result) ProcessingOfAccountsEvent?.Invoke(depositoryAccount, ProcessingOfAccountsArgs.OPEN);

            return result;
        }

        /// <summary>
        /// Закрыть депозитарный счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        public bool CloseAccount(IBankCustomer bankCustomer)
        {
            if(bankCustomer is null)
                throw new ArgumentNullException();

            var account = _depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null) return false;

            if (account.Blocking)
            {
                MessageBox.Show("Счёт заблокирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var result = _depositoryAccountsManager.Delete(account, bankCustomer);
            if (result) ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.CLOSE);

            return result;
        }

        /// <summary>
        /// Редактировать депозитарный счёт
        /// </summary>
        /// <param name="account"> Клиент банка </param>        
        public bool EditAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            var account = _depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null) return false;

            if (account.Blocking)
            {
                MessageBox.Show("Счёт заблокирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var tempDepositoryAccount = _depositoryAccountDialog.Edit(account);
            if (tempDepositoryAccount is null) return false;

            _depositoryAccountsManager.Update(tempDepositoryAccount);
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.EDIT);

            return true;
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

            if (account1.Id == account2.Id) 
            {
                MessageBox.Show("Невозможная перация!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            double? tempAmount = account2.Amount;
            bool result = _depositoryAccountsManager.Delete(account2, bankCustomer);

            if(result)
            {
                account1.Amount += tempAmount;
                _depositoryAccountsManager.Update(account1);
                ProcessingOfAccountsEvent?.Invoke(account1, ProcessingOfAccountsArgs.COMBINING);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Перевести на счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        public bool TransferToAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            var account = _depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
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
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.TRANSFER);

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

            var account = _depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
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
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.WITHDRAW);

            return result;
        }

        /// <summary>
        /// Блокировка счёта
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>       
        public bool BlockAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            var account = _depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null) return false;

            account.Blocking = true;
            _depositoryAccountsManager.Update(account);
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.BLOCK);

            return true;
        }

        /// <summary>
        /// Разблокировка счёта
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        public bool UnblockAccount(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException();

            var account = _depositoryAccountDialog.Selected(bankCustomer.DepositoryAccounts);
            if (account is null) return false;

            account.Blocking = false;
            _depositoryAccountsManager.Update(account);
            ProcessingOfAccountsEvent?.Invoke(account, ProcessingOfAccountsArgs.UNBLOCK);

            return true;
        }
        
        /// <summary>
        /// Начать расчёт по счетам
        /// </summary>
        public void StartCalculate()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 2);
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        /// <summary>
        /// Остановить расчёт по счетам
        /// </summary>
        public void StopCalculate()
        {
            _timer.Stop();
            _timer.Tick -= TimerTick;
            _timer = null;
        }

        /// <summary>
        /// Конструктор
        /// </summary>        
        public ProcessingOfDepositoryAccounts(DepositoryAccountsManager depositoryAccountsManager,
                                              DepositoryAccountDialog depositoryAccountDialog)
        {
            _depositoryAccountsManager = depositoryAccountsManager;
            _depositoryAccountDialog = depositoryAccountDialog;
        }

        /// <summary>
        /// Обработчик события таймера
        /// </summary>        
        private void TimerTick(object sender, EventArgs e)
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
    }
}
