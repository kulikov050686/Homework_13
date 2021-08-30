using Homework_13.Enums;
using Homework_13.Models;
using System.Collections.ObjectModel;

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
        ObservableCollection<BankCustomer> BankCustomers { get; set; }
    }
}
