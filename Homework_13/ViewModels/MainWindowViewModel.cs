using System;

namespace Homework_13.ViewModels
{
    /// <summary>
    /// Модель-Представление главного окна
    /// </summary>
    public class MainWindowViewModel : BaseClassViewModelINPC
    {
        /// <summary>
        /// Название окна
        /// </summary>
        public string Title { get; protected set; }
                
        #region Конструктор

        public MainWindowViewModel()
        {
            Title = "Банк ";
        }

        #endregion
    }
}
