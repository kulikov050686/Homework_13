using Homework_13.Interfaces;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс платёж
    /// </summary>
    public class Payment : IPayment
    {
        /// <summary>
        /// Сумма платежа
        /// </summary>
        public double Amount { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="amount"> Сумма платежа </param>
        public Payment(double amount)
        {
            Amount = amount;
        }
    }
}
