using Homework_13.Enums;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс кредитный счёт
    /// </summary>
    public class CreditAccount : BankAccount
    {
        /// <summary>
        /// Статус кредита
        /// </summary>
        public CreditStatus CreditStatus { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="creditStatus"> Статус кредита </param>
        public CreditAccount(int id, CreditStatus creditStatus) : base(id, AccountStatus.CREDIT)
        {
            CreditStatus = creditStatus;
        }
    }
}
