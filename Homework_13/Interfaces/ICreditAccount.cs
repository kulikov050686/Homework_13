using Homework_13.Enums;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс кредитный счёт
    /// </summary>
    public interface ICreditAccount : IBankAccount
    {
        /// <summary>
        /// Срок кредита
        /// </summary>
        byte? CreditTerm { get; set; }

        /// <summary>
        /// Статус кредита
        /// </summary>
        CreditStatus CreditStatus { get; set; }
    }
}
