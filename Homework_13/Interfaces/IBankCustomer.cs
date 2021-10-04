using Homework_13.Enums;
using System.Collections.Generic;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс Клиет Банка
    /// </summary>
    public interface IBankCustomer : IElement
    {
        /// <summary>
        /// Паспорт
        /// </summary>
        IPassport Passport { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        Status ClientStatus { get; set; }

        /// <summary>
        /// Надёжность
        /// </summary>
        Reliability Reliability { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Лист депозитарных счетов
        /// </summary>
        IList<IDepositoryAccount> DepositoryAccounts { get; set; }

        /// <summary>
        /// Лист кредитных счетов
        /// </summary>
        IList<ICreditAccount> CreditAccounts { get; set; }

        /// <summary>
        /// Метод сравнения
        /// </summary>
        /// <param name="obj"> Сравниваемый объект </param>
        bool Equals(IBankCustomer obj)
        {
            if (obj is null) return false;
            if (this == obj) return true;

            bool key = true;

            if((DepositoryAccounts == null && obj.DepositoryAccounts != null) ||
               (DepositoryAccounts != null && obj.DepositoryAccounts == null))
            {
                key = false;
            }

            if((DepositoryAccounts != null) && (obj.DepositoryAccounts != null) && key)
            {
                if(DepositoryAccounts.Count == obj.DepositoryAccounts.Count)
                {
                    for(int i = 0; i < DepositoryAccounts.Count && key; i++)
                    {
                        key = key && DepositoryAccounts[i].Equals(obj.DepositoryAccounts[i]);
                    }
                }
                else
                {
                    key = false;
                }
            }

            if((CreditAccounts == null && obj.CreditAccounts != null) ||
               (CreditAccounts != null && obj.CreditAccounts == null))
            {
                key = false;
            }

            if ((CreditAccounts != null) && (obj.CreditAccounts != null) && key)
            {
                if (CreditAccounts.Count == obj.CreditAccounts.Count)
                {
                    for (int i = 0; i < CreditAccounts.Count && key; i++)
                    {
                        key = key && CreditAccounts[i].Equals(obj.CreditAccounts[i]);
                    }
                }
                else
                {
                    key = false;
                }
            }

            if (!key) return false;

            return (Id == obj.Id) &&
                   Passport.Equals(obj.Passport) &&
                   ClientStatus == obj.ClientStatus &&
                   Reliability == obj.Reliability &&
                   PhoneNumber == obj.PhoneNumber &&
                   Email == obj.Email;
        }
    }
}
