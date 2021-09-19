using Homework_13.Enums;
using Homework_13.Interfaces;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Статус кредита
        /// </summary>
        [JsonPropertyName("CreditStatus")]
        public CreditStatus CreditStatus { get; set; }

        /// <summary>
        /// Сумма на счёте
        /// </summary>
        [JsonPropertyName("Amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// Процентная ставка
        /// </summary>
        [JsonPropertyName("InterestRate")]
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
