using Homework_13.Enums;
using Homework_13.Interfaces;
using System;

namespace Homework_13.Services
{
    /// <summary>
    /// Обработка кредитных счетов
    /// </summary>
    public class ProcessingOfCreditAccounts
    {
        /// <summary>
        /// Расчитать платежи
        /// </summary>
        /// <param name="creditAccount"> Кредитный счёт </param>
        public void CalculatePayments(ICreditAccount creditAccount)
        {
            if(creditAccount is null)
                throw new ArgumentNullException(nameof(creditAccount));

            if(creditAccount.CreditStatus == CreditStatus.ANNUITY)
            {
                /// Реализовать расчёт ануитета
            }

            if(creditAccount.CreditStatus == CreditStatus.DIFFERENTIATED)
            {
                /// Реализовать расчёт дифферинцированного
            }
        }
    }
}
