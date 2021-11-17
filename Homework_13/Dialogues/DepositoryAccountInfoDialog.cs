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
                    break;
                case ProcessingOfAccountsArgs.CLOSE:
                    dialog.ColorBackground = Brushes.Red;
                    dialog.MessageText = $"Счёт удалён\n";
                    break;
                case ProcessingOfAccountsArgs.EDIT:
                    break;
                case ProcessingOfAccountsArgs.COMBINING:
                    break;
                case ProcessingOfAccountsArgs.TRANSFER:
                    break;
                case ProcessingOfAccountsArgs.WITHDRAW:
                    break;
                case ProcessingOfAccountsArgs.BLOCK:
                    break;
                case ProcessingOfAccountsArgs.UNBLOCK:
                    break;
            }

            dialog.Show();
            dialog.Close();
        }

        void IInformationDialog<IDepositoryAccount>.Dialog(IDepositoryAccount data) { }
    }
}
