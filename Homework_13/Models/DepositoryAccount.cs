using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс Депозитарный счёт
    /// </summary>
    public class DepositoryAccount : BaseClassModelINPC, IDepositoryAccount
    {
        #region Закрытые поля

        private int _id = 0;
        private bool _blocking = false;
        private DepositStatus _depositStatus = DepositStatus.WITHCAPITALIZATION;
        private double? _amount = 0;
        private double? _interestRate = 0;

        #endregion

        /// <summary>
        /// Идентификатор
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id
        {
            get => _id; 
            set
            {
                if (value < 0)
                    throw new ArgumentException("Невозможный идентификатор!!!");

                Set(ref _id, value);
            }
        }

        /// <summary>
        /// Блокировка депозитарного счёта
        /// </summary>
        [JsonPropertyName("Blocking")]
        public bool Blocking
        {
            get => _blocking;
            set => Set(ref _blocking, value);
        }

        /// <summary>
        /// Статус депозита
        /// </summary>
        [JsonPropertyName("DepositStatus")]
        public DepositStatus DepositStatus
        {
            get => _depositStatus;
            set => Set(ref _depositStatus, value);
        }

        /// <summary>
        /// Сумма на счёте
        /// </summary>
        [JsonPropertyName("Amount")]
        public double? Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Невозможная сумма!!!");

                Set(ref _amount, value);
            }
        }

        /// <summary>
        /// Процентная ставка
        /// </summary>
        [JsonPropertyName("InterestRate")]
        public double? InterestRate
        {
            get => _interestRate;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Невозможная процентная ставка!!!");

                Set(ref _interestRate, value);
            }
        }

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
            Id = id;
            Amount = amount;
            InterestRate = interestRate;
            DepositStatus = depositStatus;
        }
    }
}
