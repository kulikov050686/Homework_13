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
    }
}
