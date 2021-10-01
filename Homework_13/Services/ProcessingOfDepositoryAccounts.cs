using Homework_13.Interfaces;
using System;
using System.Collections.Generic;

namespace Homework_13.Services
{
    public class ProcessingOfDepositoryAccounts : IProcessingOfAccounts<IDepositoryAccount>
    {
        #region Закрытые поля

        DepositoryAccountsManager _depositoryAccountsManager;
        DepositoryAccountDialog _depositoryAccountDialog;

        #endregion

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

        public void TransferToAccount(IBankCustomer bankCustomer)
        {
            throw new NotImplementedException();
        }

        public void StartCalculate()
        {
            throw new NotImplementedException();
        }

        public void StopCalculate()
        {
            throw new NotImplementedException();
        }

        public ProcessingOfDepositoryAccounts(DepositoryAccountsManager depositoryAccountsManager,
                                              DepositoryAccountDialog depositoryAccountDialog)
        {
            _depositoryAccountsManager = depositoryAccountsManager;
            _depositoryAccountDialog = depositoryAccountDialog;
        }
    }
}
