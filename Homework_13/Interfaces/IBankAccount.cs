using Homework_13.Enums;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс Банковский счёт
    /// </summary>
    public interface IBankAccount : IElement
    {
        /// <summary>
        /// Сумма на счёте
        /// </summary>
        double? Amount { get; set; }

        /// <summary>
        /// Процентная ставка
        /// </summary>
        double? InterestRate { get; set; }

        /// <summary>
        /// Статус счёта
        /// </summary>
        AccountStatus AccountStatus { get; }
    }
}
