﻿using Homework_13.Enums;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс Депозитный счёт
    /// </summary>
    public class DepositoryAccount : BankAccount
    {
        /// <summary>
        /// Статус депозита
        /// </summary>
        public DepositStatus DepositStatus { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="depositStatus"> Статус депозита </param>
        public DepositoryAccount(int id, DepositStatus depositStatus) : base(id, AccountStatus.DEPOSITORY)
        {
            DepositStatus = depositStatus;
        }
    }
}
