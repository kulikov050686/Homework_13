using Homework_13.Interfaces;
using Homework_13.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;

namespace Homework_13.Services
{
    /// <summary>
    /// Класс сервиса диалоговых окон по сохранению и выгрузки данных из файла
    /// </summary>    
    public class FileDialog : IFileDialogService<IList<Department>>
    {
        #region Закрытые поля

        private string _pathFile;
        private FileIOService _fileIOService;

        #endregion

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string PathFile => _pathFile;

        /// <summary>
        /// Открывает диалоговое окно для сохранения в файл
        /// </summary>
        /// <param name="data"> Сохраняемые данные </param>
        public void SaveFileDialog(IList<Department> data)
        {
            SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.Title = "Сохранить файл";
            saveFileDialog.Filter = "files (*.json)|*.json";
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (saveFileDialog.ShowDialog() == true)
            {
                _pathFile = saveFileDialog.FileName;

                if (Path.GetExtension(PathFile) == ".json")
                {
                    _fileIOService.SaveAsJSON(PathFile, data);                    
                }
            };
        }

        /// <summary>
        /// Открывает диалоговое окно для чтения из файла
        /// </summary>  
        public IList<Department> OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Title = "Открыть файл";
            openFileDialog.Filter = "files (*.json)|*.json";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                _pathFile = openFileDialog.FileName;

                if (Path.GetExtension(PathFile) == ".json")
                {
                    return _fileIOService.OpenAsJSON(PathFile);
                }
            }

            return null;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public FileDialog(FileIOService fileIOService)
        {
            _fileIOService = fileIOService;
        }
    }
}
