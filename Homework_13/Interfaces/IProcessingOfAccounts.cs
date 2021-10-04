using Homework_13.Infrastructure;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Обработка Счетов
    /// </summary>
    public interface IProcessingOfAccounts
    {
        /// <summary>
        /// Событие возникающее при обработке счетов
        /// </summary>
        event ProcessingOfAccountsEventHandler ProcessingOfAccountsEvent;

        /// <summary>
        /// Открыть счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        bool OpenAccount(IBankCustomer bankCustomer);

        /// <summary>
        /// Закрыть счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        bool CloseAccount(IBankCustomer bankCustomer);

        /// <summary>
        /// Редактировать счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        bool EditAccount(IBankCustomer bankCustomer);

        /// <summary>
        /// Объединить счета
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>               
        bool CombiningAccounts(IBankCustomer bankCustomer);

        /// <summary>
        /// Начать расчёт по счетам
        /// </summary>
        void StartCalculate();

        /// <summary>
        /// Остановить расчёт по счетам
        /// </summary>
        void StopCalculate();
    }
}
