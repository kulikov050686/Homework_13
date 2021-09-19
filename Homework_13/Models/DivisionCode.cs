using Homework_13.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс код подразделения
    /// </summary>
    public class DivisionCode : IDivisionCode
    {
        /// <summary>
        /// Левая часть кода подразделения
        /// </summary>
        [JsonPropertyName("Left")]
        public int? Left { get; }

        /// <summary>
        /// Правая часть кода подразделения
        /// </summary>
        [JsonPropertyName("Right")]
        public int? Right { get; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="left"> Левая часть кода </param>
        /// <param name="right"> Правая часть кода </param>
        public DivisionCode(int? left, int? right)
        {
            if (left <= 0) 
                throw new ArgumentException("Невозможное значение!!!");
            Left = left;

            if (right <= 0) 
                throw new ArgumentException("Невозможное значение!!!");
            Right = right;
        }        
    }
}
