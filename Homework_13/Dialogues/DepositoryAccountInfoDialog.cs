using Homework_13.Enums;
using Homework_13.Interfaces;

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

        }

        void IInformationDialog<IDepositoryAccount>.Dialog(IDepositoryAccount data) { }
    }
}
