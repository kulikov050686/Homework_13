using System.Collections.Generic;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Обработка Счетов
    /// </summary>
    public interface IProcessingOfAccounts<T> where T: IBankAccount
    {
        /// <summary>
        /// Расчитать счёт
        /// </summary>
        /// <param name="account"> Счёт </param>
        void Calculate(T account);

        /// <summary>
        /// Расчитать счета
        /// </summary>
        /// <param name="accounts"> Стисок счетов </param>
        void Calculate(IList<T> accounts);
    }
}
