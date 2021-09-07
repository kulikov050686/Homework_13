using Homework_13.Enums;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс депозитарный счёт
    /// </summary>
    public interface IDepositoryAccount : IBankAccount
    {
        /// <summary>
        /// Статус депозита
        /// </summary>
        public DepositStatus DepositStatus { get; set; }
    }
}
