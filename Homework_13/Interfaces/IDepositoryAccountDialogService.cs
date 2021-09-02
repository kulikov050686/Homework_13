using Homework_13.Models;
using System.Collections.Generic;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон по работе с депозитарным счётом
    /// </summary>
    public interface IDepositoryAccountDialogService
    {
        /// <summary>
        /// Создание нового депозитарного счёта
        /// </summary>             
        DepositoryAccount CreateNewDepositoryAccount();

        /// <summary>
        /// Редактировать данные депозитарного счёта
        /// </summary>
        /// <param name="depositoryAccount"> Депозитарный счёт </param>        
        DepositoryAccount EditDepositoryAccountData(DepositoryAccount depositoryAccount);

        /// <summary>
        /// Объединить депозитарные счета в один счёт
        /// </summary>
        /// <param name="depositoryAccounts"> Список депозитарных счетов </param>        
        public DepositoryAccount CombiningDepositoryAccounts(IEnumerable<DepositoryAccount> depositoryAccounts);
    }
}
