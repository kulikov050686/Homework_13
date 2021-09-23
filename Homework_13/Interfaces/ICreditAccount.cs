using Homework_13.Enums;
using System.Collections.Generic;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс кредитный счёт
    /// </summary>
    public interface ICreditAccount : IBankAccount
    {
        /// <summary>
        /// Статус кредита
        /// </summary>
        CreditStatus CreditStatus { get; set; }

        /// <summary>
        /// Список платежей
        /// </summary>
        IList<IPayment> Payments { get; set; }
    }
}
