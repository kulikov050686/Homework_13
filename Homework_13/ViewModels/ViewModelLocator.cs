using Microsoft.Extensions.DependencyInjection;

namespace Homework_13.ViewModels
{
    /// <summary>
    /// Класс для доступа к конкретным Моделям-Представления
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Модель-представления главного окна
        /// </summary>
        public MainWindowViewModel MainWindowVM => App.Host.Services.GetRequiredService<MainWindowViewModel>();

        /// <summary>
        /// Модель-представления главного контрола
        /// </summary>
        public MainUserControlViewModel MainUserControlVM => App.Host.Services.GetRequiredService<MainUserControlViewModel>();

        /// <summary>
        /// Модель-представление контрола главного меню
        /// </summary>
        public MainMenuUserControlViewModel MainMenuUserControlVM => App.Host.Services.GetRequiredService<MainMenuUserControlViewModel>();
    }
}
