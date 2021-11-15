﻿using System.Collections.Generic;
using System;
using Homework_13.Interfaces;
using Homework_13.Enums;

namespace Homework_13.Services
{
    /// <summary>
    /// Менеджер Клиента банка
    /// </summary>
    public class BankCustomersManager
    {
        #region Закрытые поля

        BankCustomerRepository _bankCustomerRepository;
        DepartmentsManager _departmentsManager;

        #endregion

        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        public IList<IBankCustomer> BankCustomers => _bankCustomerRepository.GetAll();

        /// <summary>
        /// Обновление данных клиента банка и сохранение в репозитории
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        public void Update(IBankCustomer bankCustomer)
        {
            _bankCustomerRepository.Update(bankCustomer.Id, bankCustomer);
        }

        /// <summary>
        /// Добавление нового клиента банка в департамент
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        /// <param name="department"> Департамент </param>        
        public bool Create(IBankCustomer bankCustomer,
                           IDepartment department)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Добавляемый клиент банка не может быть null!!!");
            if (department is null)
                throw new ArgumentNullException(nameof(department), "Департамент не может быть null!!!");

            var selectedDepartment = _departmentsManager.Get(department.Name);
            if (selectedDepartment is null) return false;

            department.BankCustomers.Add(bankCustomer);
            _bankCustomerRepository.Add(bankCustomer);

            return true;
        }
        
        /// <summary>
        /// Удалить клиента банка из департамента
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        /// <param name="department"> Департамент </param>
        public bool Delete(IBankCustomer bankCustomer,
                           IDepartment department)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Добавляемый клиент банка не может быть null!!!");
            if (department is null)
                throw new ArgumentNullException(nameof(department), "Департамент не может быть null!!!");

            var selectedDepartment = _departmentsManager.Get(department.Name);
            if (selectedDepartment is null) return false;
            
            if(department.BankCustomers.Remove(bankCustomer))
            {
                _bankCustomerRepository.Remove(bankCustomer);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получить клиента банка по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор </param>        
        public IBankCustomer Get(int id) => _bankCustomerRepository.Get(id);

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="bankCustomerRepository"> Хранилище клиентов банка </param>
        /// <param name="departmentsManager"> Хранилище департаментов банка </param>
        public BankCustomersManager(BankCustomerRepository bankCustomerRepository,
                                    DepartmentsManager departmentsManager)
        {
            _bankCustomerRepository = bankCustomerRepository;
            _departmentsManager = departmentsManager;

            _bankCustomerRepository.RepositoryEvent += OnBankCustomerRepositoryEvent;
        }
        
        private void OnBankCustomerRepositoryEvent(object sender, RepositoryArgs args)
        {
            /// реализовать действия на событие
        }
    }
}
