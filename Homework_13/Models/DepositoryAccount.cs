using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Статус депозита
        /// </summary>
        [JsonPropertyName("DepositStatus")]
        public DepositStatus DepositStatus { get; set; }

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
        public AccountStatus AccountStatus => AccountStatus.DEPOSITORY;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="amount"> Сумма </param>
        /// <param name="interestRate"> Процентная ставка </param>
        /// <param name="depositStatus"> Статус депозита </param>
        public DepositoryAccount(int id, 
                                 double? amount,
                                 double? interestRate,
                                 DepositStatus depositStatus)
        {
            if (id < 0)
                throw new ArgumentException("Невозможный идентификатор!!!");
            if (amount < 0)
                throw new ArgumentException("Невозможная сумма кредита!!!");
            if (interestRate <= 0)
                throw new ArgumentException("Невозможная процентная ставка!!!");

            Id = id;
            Amount = amount;
            InterestRate = interestRate;
            DepositStatus = depositStatus;
        }
    }
}
