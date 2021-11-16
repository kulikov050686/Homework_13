namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс диалога информации
    /// </summary>    
    public interface IInformationDialog<T>
    {
        /// <summary>
        /// Диалог информации
        /// </summary>
        /// <param name="data"> Данные для отображения информации </param>
        void Dialog(T data);
    }
}
