namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс журнал действий
    /// </summary>    
    public interface IActionLog
    {
        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <param name="data"> Добавляемая запись </param>
        void AddAnEntry<T>(string nameFile, T data);
    }
}
