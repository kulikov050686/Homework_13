using Homework_13.Enums;
using Homework_13.Interfaces;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс Депозитарный счёт
    /// </summary>
    public class DepositoryAccount : IDepositoryAccount
    {        
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Статус депозита
        /// </summary>
        public DepositStatus DepositStatus { get; set; }

        /// <summary>
        /// Сумма на счёте
        /// </summary>
        public double? Amount { get; set; }

        /// <summary>
        /// Процентная ставка
        /// </summary>
        public double? InterestRate { get; set; }

        /// <summary>
        /// Статус счёта
        /// </summary>
        public AccountStatus AccountStatus => AccountStatus.DEPOSITORY;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="depositStatus"> Статус депозита </param>
        public DepositoryAccount(int id, DepositStatus depositStatus)
        {
            DepositStatus = depositStatus;
            Id = id;
        }
    }
}
