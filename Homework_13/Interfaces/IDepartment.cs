using Homework_13.Enums;
using System.Collections.Generic;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс департамент
    /// </summary>    
    public interface IDepartment : IEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Статус департамента
        /// </summary>
        Status StatusDepartment { get; set; }

        /// <summary>
        /// Лист клиентов банка
        /// </summary>
        IList<IBankCustomer> BankCustomers { get; set; }
    }
}
