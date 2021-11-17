using Homework_13.Enums;
using Homework_13.Interfaces;
using Homework_13.Views;
using System.Windows.Media;

namespace Homework_13.Dialogues
{
    /// <summary>
    /// Класс сервиса диалоговых окон по информированию о дипозитарном счёте
    /// </summary>
    public class DepositoryAccountInfoDialog : IInformationDialog<IDepositoryAccount>
    {
        /// <summary>
        /// Диалог информации о депозитарном счёте
        /// </summary>
        /// <param name="data"> Депозитарный счёт </param>
        /// <param name="args"> Действия со счётом </param>
        public void Dialog(IDepositoryAccount data, ProcessingOfAccountsArgs args)
        {
            if (data is null) return;
            var dialog = new InfoWindow();

            switch (args)
            {
                case ProcessingOfAccountsArgs.OPEN:
                    dialog.ColorBackground = Brushes.Green;
                    dialog.MessageText = $"Счёт открыт\n";
                    break;
                case ProcessingOfAccountsArgs.CLOSE:
                    dialog.ColorBackground = Brushes.Red;
                    dialog.MessageText = $"Счёт удалён\n";
                    break;
                case ProcessingOfAccountsArgs.EDIT:
                    dialog.ColorBackground = Brushes.Blue;
                    dialog.MessageText = $"Счёт отредактирован\n";
                    break;
                case ProcessingOfAccountsArgs.COMBINING:
                    dialog.ColorBackground = Brushes.Gray;
                    dialog.MessageText = $"Счёта объеденены\n";
                    break;
                case ProcessingOfAccountsArgs.TRANSFER:
                    dialog.ColorBackground = Brushes.Brown;
                    dialog.MessageText = $"Перевод на счёт\n";
                    break;
                case ProcessingOfAccountsArgs.WITHDRAW:
                    dialog.ColorBackground = Brushes.Aqua;
                    dialog.MessageText = $"Вывод со счёта\n";
                    break;
                case ProcessingOfAccountsArgs.BLOCK:
                    dialog.ColorBackground = Brushes.Red;
                    dialog.MessageText = $"Счёт заблокирован\n";
                    break;
                case ProcessingOfAccountsArgs.UNBLOCK:
                    dialog.ColorBackground = Brushes.Blue;
                    dialog.MessageText = $"Счёт разблоктрован\n";
                    break;
            }

            dialog.Show();
            dialog.Close();
        }

        void IInformationDialog<IDepositoryAccount>.Dialog(IDepositoryAccount data) { }
    }
}
