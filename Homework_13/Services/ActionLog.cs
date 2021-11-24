using Homework_13.Interfaces;
using System.IO;
using System;

namespace Homework_13.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionLog : IActionLog
    {
        #region Закрытые методы

        //IFileIOService _fileIOService;

        #endregion

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="data"></param>
        public void AddAnEntry<T>(string nameFile, T data)
        {
            if (string.IsNullOrWhiteSpace(nameFile) || data is null)
                throw new ArgumentNullException();

            string path = Directory.GetCurrentDirectory() + $"\\{nameFile}";
            
            //try
            //{
            //    if (Path.GetExtension(path) == ".json")
            //    {
            //        _fileIOService.SaveAsJSON(path, data);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new ArithmeticException(ex.Message);
            //}
        }

        public ActionLog(DepartmentFileIOService fileIOService)
        {
            //_fileIOService = fileIOService;
        }
    }
}
