using System.Windows;

namespace Homework_13.Commands
{
    /// <summary>
    /// Класс команда закрытия окна
    /// </summary>
    public class CloseWindowCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => parameter is Window;        

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            var window = (Window)parameter;
            window.Close();
        }
    }
}
