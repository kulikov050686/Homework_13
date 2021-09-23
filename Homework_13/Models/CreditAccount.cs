using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        public CreditStatus CreditStatus { get; set; }

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
        /// Список платежей
        /// </summary>        
        public IList<IPayment> Payments { get; set; } = new ObservableCollection<IPayment>();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="amount"> Сумма кредита </param>
        /// <param name="interestRate"> Процентная ставка </param>
        /// <param name="creditStatus"> Статус кредита </param>
        public CreditAccount(int id, 
                             double amount, 
                             double interestRate,
                             CreditStatus creditStatus)
        {
            if (id < 0)
                throw new ArgumentException("Невозможный идентификатор!!!");
            if (amount < 0)
                throw new ArgumentException("Невозможная сумма кредита!!!");
            if(interestRate <= 0)
                throw new ArgumentException("Невозможная процентная ставка!!!");

            Id = id;                       
            Amount = amount;
            InterestRate = interestRate;
            CreditStatus = creditStatus;
        }
    }
}
