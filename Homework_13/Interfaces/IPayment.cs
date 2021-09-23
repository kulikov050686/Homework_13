namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс платёж
    /// </summary>
    public interface IPayment
    {
        /// <summary>
        /// Сумма платежа
        /// </summary>
        double Amount { get; }
    }
}
