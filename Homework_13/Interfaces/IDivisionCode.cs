using System;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс код подразделения
    /// </summary>
    public interface IDivisionCode
    {
        /// <summary>
        /// Левая часть кода подразделения
        /// </summary>
        int? Left { get; }

        /// <summary>
        /// Правая часть кода подразделения
        /// </summary>
        int? Right { get; }

        /// <summary>
        /// Метод сравнения
        /// </summary>
        /// <param name="obj"> Сравниваемй объект </param>
        public bool Equals(IDivisionCode obj)
        {
            if (obj is null) return false;
            if (this == obj) return true;

            return Left == obj.Left &&
                   Right == obj.Right;
        }
    }
}
