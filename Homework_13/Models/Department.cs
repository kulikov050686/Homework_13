using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс департамент
    /// </summary>
    public class Department : IDepartment
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Статус департамента
        /// </summary>
        public Status StatusDepartment { get; set; }

        /// <summary>
        /// Лист клиентов банка
        /// </summary>
        public IList<IBankCustomer> BankCustomers { get; set; } = new ObservableCollection<IBankCustomer>();
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Название </param>
        /// <param name="statusDepartment"> Статус </param>
        public Department(int id,
                          string name,
                          Status statusDepartment)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("Название департамента не может быть тустым или null!!!");
            if (id < 0) 
                throw new ArgumentException("Значение идентификатора не верно!!!");

            Id = id;
            Name = name;
            StatusDepartment = statusDepartment;
        }
    }
}
