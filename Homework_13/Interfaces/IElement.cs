namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интрефейс элемент
    /// </summary>
    public interface IElement : IEntity
    {
        /// <summary>
        /// Блокировка
        /// </summary>
        bool Blocking { get; set; }
    }
}
