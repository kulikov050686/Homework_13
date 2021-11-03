using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс Клиент Банка
    /// </summary>
    public class BankCustomer : BaseClassModelINPC, IBankCustomer
    {
        #region Закрытые поля

        private int _id = 0;
        private bool _blocking = false;
        private IPassport _passport = null;
        private Status _clientStatus = Status.USUAL;
        private Reliability _reliability = Reliability.FIRST;
        private string _phoneNumber = null;
        private string _email = null;
        private string _description = null;

        #endregion

        /// <summary>
        /// Идентификатор
        /// </summary>
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
        /// Блокировка
        /// </summary>
        public bool Blocking
        {
            get => _blocking;
            set => Set(ref _blocking, value);            
        }

        /// <summary>
        /// Паспорт
        /// </summary>
        public IPassport Passport
        {
            get => _passport;
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Паспорт не может быть null!!!");

                Set(ref _passport, value);
            }
        }

        /// <summary>
        /// Статус
        /// </summary>
        public Status ClientStatus
        {
            get => _clientStatus;
            set => Set(ref _clientStatus, value);
        }

        /// <summary>
        /// Надёжность
        /// </summary>
        public Reliability Reliability
        {
            get => _reliability;
            set => Set(ref _reliability, value);
        }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        /// <summary>
        /// Лист депозитарных счетов
        /// </summary>
        public IList<IDepositoryAccount> DepositoryAccounts { get; set; } = new ObservableCollection<IDepositoryAccount>();

        /// <summary>
        /// Лист кредитных счетов
        /// </summary>
        public IList<ICreditAccount> CreditAccounts { get; set; } = new ObservableCollection<ICreditAccount>();
        
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
            Id = id;
            Passport = passport;
            ClientStatus = clientStatus;
            Reliability = reliability;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
