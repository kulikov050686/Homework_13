﻿using System.Collections.Generic;
using System;
using Homework_13.Interfaces;

namespace Homework_13.Services
{
    /// <summary>
    /// Менеджер Клиента банка
    /// </summary>
    public class BankCustomersManager
    {
        #region Закрытые поля

        BankCustomerRepository _bankCustomers;
        DepartmentRepository _departments;

        #endregion

        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        public IList<IBankCustomer> BankCustomers => _bankCustomers.GetAll();

        /// <summary>
        /// Получить список всех департаментов
        /// </summary>
        public IList<IDepartment> Departments => _departments.GetAll();

        /// <summary>
        /// Обновление данных клиента банка и сохранение в репозитории
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        public void Update(IBankCustomer bankCustomer)
        {
            _bankCustomers.Update(bankCustomer.Id, bankCustomer);
        }

        /// <summary>
        /// Добавление нового клиента банка в департамент
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        /// <param name="department"> Департамент </param>        
        public bool CreateNewBankCustomer(IBankCustomer bankCustomer, IDepartment department)
        {
            if (bankCustomer is null) 
                throw new ArgumentNullException(nameof(bankCustomer), "Добавляемый клиент банка не может быть null!!!");
            if (department is null)
                throw new ArgumentNullException(nameof(department), "Департамент не может быть null!!!");

            var selectedDepartment = _departments.Get(department.Name);
            if (selectedDepartment is null) return false;

            department.BankCustomers.Add(bankCustomer);
            _bankCustomers.Add(bankCustomer);

            return true;
        }
        
        /// <summary>
        /// Удалить клиента банка из департамента
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        /// <param name="department"> Департамент </param>        
        public bool DeleteBankCustomer(IBankCustomer bankCustomer, IDepartment department)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Добавляемый клиент банка не может быть null!!!");
            if (department is null)
                throw new ArgumentNullException(nameof(department), "Департамент не может быть null!!!");

            var selectedDepartment = _departments.Get(department.Name);

            if (selectedDepartment is null) return false;
            
            if(department.BankCustomers.Remove(bankCustomer))
            {
                _bankCustomers.Remove(bankCustomer);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="bankCustomerRepository"> Хранилище клиентов банка </param>
        /// <param name="departmentRepository"> Хранилище департаментов банка </param>
        public BankCustomersManager(BankCustomerRepository bankCustomerRepository, 
                                    DepartmentRepository departmentRepository)
        {
            _bankCustomers = bankCustomerRepository;
            _departments = departmentRepository;
        }
    }
}
