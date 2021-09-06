namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон сохранения и открытия файла
    /// </summary>    
    public interface IFileDialogService<T>
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        string PathFile { get; }

        /// <summary>
        /// Открывает диалоговое окно для сохранения в файл
        /// </summary>
        /// <param name="data"> Сохраняемые данные </param>
        void SaveFileDialog(T data);

        /// <summary>
        /// Открывает диалоговое окно для чтения из файла
        /// </summary>        
        T OpenFileDialog();
    }
}
