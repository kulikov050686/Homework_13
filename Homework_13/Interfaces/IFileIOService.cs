namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса загрузки и выгрузки данных из файла
    /// </summary>
    public interface IFileIOService<T>
    {
        /// <summary>
        /// Сохранить данные в файл формата JSON
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        /// <param name="data"> Сохраняемые данные </param>
        void SaveAsJSON(string pathFile, T data);

        /// <summary>
        /// Загрузить данные из файла формата JSON
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        T OpenAsJSON(string pathFile);
    }
}
