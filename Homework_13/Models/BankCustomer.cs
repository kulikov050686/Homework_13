using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace Homework_13.Models
{
    /// <summary>
    /// Базовый класс Клиент Банка
    /// </summary>
    public class BankCustomer : IBankCustomer
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Паспорт
        /// </summary>
        public IPassport Passport { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public Status ClientStatus { get; set; }

        /// <summary>
        /// Надёжность
        /// </summary>
        public Reliability Reliability { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Лист депозитарных счетов
        /// </summary>
        public ObservableCollection<DepositoryAccount> DepositoryAccounts { get; set; } = new ObservableCollection<DepositoryAccount>();

        /// <summary>
        /// Лист кредитных счетов
        /// </summary>
        public ObservableCollection<CreditAccount> CreditAccounts { get; set; } = new ObservableCollection<CreditAccount>();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="passport"> Паспорт </param>
        /// <param name="clientStatus"> Статус </param>
        /// <param name="reliability"> Надёжность </param>
        /// <param name="phoneNumber"> Номер телефон </param>
        /// <param name="email"> Электронная почта </param>
        public BankCustomer(int id,
                            IPassport passport,
                            Status clientStatus,
                            Reliability reliability,
                            string phoneNumber = null,                            
                            string email = null)
        {
            if(id < 0) 
                throw new ArgumentException("Невозможный идентификатор!!!");
            if (passport is null)
                throw new ArgumentNullException("Паспорт не может быть null!!!");

            Id = id;
            Passport = passport;
            ClientStatus = clientStatus;
            Reliability = reliability;

            PhoneNumber = phoneNumber;            
            Email = email;
        }
    }
}
