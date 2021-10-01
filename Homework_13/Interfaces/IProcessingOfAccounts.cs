namespace Homework_13.Interfaces
{
    /// <summary>
    /// Обработка Счетов
    /// </summary>
    public interface IProcessingOfAccounts<T> where T: IBankAccount
    {
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
        /// Перевод на счёт
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        void TransferToAccount(IBankCustomer bankCustomer);

        void StartCalculate();

        void StopCalculate();
    }
}
