namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса загрузки и выгрузки данных из файла XML
    /// </summary>    
    public interface IFileIOServiceXML<T>
    {
        /// <summary>
        /// Сохранить данные в файл XML
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        /// <param name="data"> Сохраняемые данные </param>
        void SaveAsXML(string pathFile, T data);

        /// <summary>
        /// Загрузить данные из файла XML
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>        
        T OpenAsXML(string pathFile);
    }
}
