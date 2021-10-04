using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
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
        /// Блокировка кредитного чсёта
        /// </summary>
        [JsonPropertyName("Blocking")]
        public bool Blocking { get; set; } = false;

        /// <summary>
        /// Срок кредита
        /// </summary>
        [JsonPropertyName("CreditTerm")]
        public byte? CreditTerm { get; set; }

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
        /// <param name="amount"> Сумма кредита </param>
        /// <param name="interestRate"> Процентная ставка </param>
        /// <param name="creditTerm"> Срок кредитования </param>
        /// <param name="creditStatus"> Статус кредита </param>
        public CreditAccount(int id,
                             double? amount, 
                             double? interestRate,
                             byte? creditTerm,
                             CreditStatus creditStatus)
        {
            if (id < 0)
                throw new ArgumentException("Невозможный идентификатор!!!");
            if (amount < 0)
                throw new ArgumentException("Невозможная сумма кредита!!!");
            if(interestRate <= 0)
                throw new ArgumentException("Невозможная процентная ставка!!!");
            if(creditTerm == 0)
                throw new ArgumentException("Невозможный срок кредита!!!");

            Id = id;
            Amount = amount;
            InterestRate = interestRate;
            CreditTerm = creditTerm;
            CreditStatus = creditStatus;
        }
    }
}
