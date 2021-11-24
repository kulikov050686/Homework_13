namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса загрузки и выгрузки данных из текстового файла
    /// </summary>    
    public interface IFileIOServiceTEXT<T>
    {
        /// <summary>
        /// Сохранить данные в текстовый файл
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        /// <param name="data"> Сохраняемые данные </param>
        void SaveAsTEXT(string pathFile, T data);

        /// <summary>
        /// Загрузить данные из текстового файла
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>        
        T OpenAsTEXT(string pathFile);
    }
}
