namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса загрузки и выгрузки данных из файла JSON
    /// </summary>
    public interface IFileIOServiceJSON<T>
    {
        /// <summary>
        /// Сохранить данные в файл JSON
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        /// <param name="data"> Сохраняемые данные </param>       
        void SaveAsJSON(string pathFile, T data);

        /// <summary>
        /// Загрузить данные из файла JSON
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        T OpenAsJSON(string pathFile);             
    }
}
