using Homework_13.Enums;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс клиент банка для парсинга файлов Json 
    /// </summary>
    public class JsonBankCustomer
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Блокировка
        /// </summary>
        [JsonPropertyName("Blocking")]
        public bool Blocking { get; set; }

        /// <summary>
        /// Паспорт
        /// </summary>
        [JsonPropertyName("Passport")]
        public JsonPassport Passport { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [JsonPropertyName("ClientStatus")]
        public Status ClientStatus { get; set; }

        /// <summary>
        /// Надёжность
        /// </summary>
        [JsonPropertyName("Reliability")]
        public Reliability Reliability { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [JsonPropertyName("PhoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Лист депозитарных счетов
        /// </summary>
        [JsonPropertyName("DepositoryAccounts")]
        public ObservableCollection<DepositoryAccount> DepositoryAccounts { get; set; }
    }
}
