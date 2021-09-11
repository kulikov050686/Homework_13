using Homework_13.Enums;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс департамента для парсинга файлов Json 
    /// </summary>
    public class JsonDepartment
    {
        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Статус департамента
        /// </summary>
        [JsonPropertyName("StatusDepartment")]
        public Status StatusDepartment { get; set; }

        /// <summary>
        /// Лист клиентов банка
        /// </summary>
        [JsonPropertyName("BankCustomers")]
        public ObservableCollection<JsonBankCustomer> BankCustomers { get; set; }
    }
}
