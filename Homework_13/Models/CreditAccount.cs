using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс кредитный счёт
    /// </summary>
    public class CreditAccount : BaseClassModelINPC, ICreditAccount
    {
        #region Закрытые поля

        private int _id = 0;
        private bool _blocking = false;
        private byte? _creditTerm = 0;
        private CreditStatus _creditStatus = CreditStatus.ANNUITY;
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
                if(value < 0)
                    throw new ArgumentException("Невозможный идентификатор!!!");

                Set(ref _id, value);
            }
        }

        /// <summary>
        /// Блокировка кредитного чсёта
        /// </summary>
        [JsonPropertyName("Blocking")]
        public bool Blocking
        {
            get => _blocking; 
            set => Set(ref _blocking, value);
        }

        /// <summary>
        /// Срок кредита
        /// </summary>
        [JsonPropertyName("CreditTerm")]
        public byte? CreditTerm
        {
            get => _creditTerm; 
            set
            {
                if (value == 0)
                    throw new ArgumentException("Невозможный срок кредита!!!");

                Set(ref _creditTerm, value);
            }
        }

        /// <summary>
        /// Статус кредита
        /// </summary>        
        [JsonPropertyName("CreditStatus")]
        public CreditStatus CreditStatus
        {
            get => _creditStatus;
            set => Set(ref _creditStatus, value);
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
                    throw new ArgumentException("Невозможная сумма кредита!!!");

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
            Id = id;
            Amount = amount;
            InterestRate = interestRate;
            CreditTerm = creditTerm;
            CreditStatus = creditStatus;
        }
    }
}
