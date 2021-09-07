using Homework_13.Enums;
using Homework_13.Interfaces;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс кредитный счёт
    /// </summary>
    public class CreditAccount : ICreditAccount
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Статус кредита
        /// </summary>
        public CreditStatus CreditStatus { get; }

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
        public AccountStatus AccountStatus => AccountStatus.CREDIT;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="creditStatus"> Статус кредита </param>
        public CreditAccount(int id, CreditStatus creditStatus)
        {
            CreditStatus = creditStatus;
            Id = id;
        }
    }
}
