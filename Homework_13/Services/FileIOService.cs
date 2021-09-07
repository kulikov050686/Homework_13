using Homework_13.Interfaces;
using Homework_13.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Homework_13.Services
{
    /// <summary>
    /// Класс загрузки и выгрузки данных из файла
    /// </summary>    
    public class FileIOService : IFileIOService<IList<IDepartment>>
    {
        /// <summary>
        /// Сохранить данные в файл формата JSON
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        /// <param name="data"> Сохраняемые данные </param>
        public void SaveAsJSON(string pathFile, IList<IDepartment> data)
        {
            using (StreamWriter writer = new StreamWriter(pathFile, false))
            {
                string output = JsonConvert.SerializeObject(data, Formatting.Indented);
                writer.Write(output);
            }
        }

        /// <summary>
        /// Загрузить данные из файла формата JSON
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        public IList<IDepartment> OpenAsJSON(string pathFile)
        {
            using (var reader = File.OpenText(pathFile))
            {
                var fileTaxt = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IList<IDepartment>>(fileTaxt);
            }
        }        
    }
}
