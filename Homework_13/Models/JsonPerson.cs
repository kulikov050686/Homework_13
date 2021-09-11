using Homework_13.Enums;
using System;
using System.Text.Json.Serialization;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс человек для парсинга файлов Json
    /// </summary>
    public class JsonPerson
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonPropertyName("Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [JsonPropertyName("Patronymic")]
        public string Patronymic { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [JsonPropertyName("Gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        [JsonPropertyName("Birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        [JsonPropertyName("PlaceOfBirth")]
        public string PlaceOfBirth { get; set; }

        /// <summary>
        /// Место жительства (прописка)
        /// </summary>
        [JsonPropertyName("PlaceOfResidence")]
        public Address PlaceOfResidence { get; set; }

        /// <summary>
        /// Место регистрации (место непосредственного проживания)
        /// </summary>
        [JsonPropertyName("PlaceOfRegistration")]
        public Address PlaceOfRegistration { get; set; }
    }
}
