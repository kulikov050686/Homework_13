using Homework_13.Enums;
using Homework_13.Interfaces;

namespace Homework_13.Dialogues
{
    public class DepositoryAccountInfoDialog : IInformationDialog<IDepositoryAccount>
    {
        public void Dialog(IDepositoryAccount data, ProcessingOfAccountsArgs args)
        {

        }

        void IInformationDialog<IDepositoryAccount>.Dialog(IDepositoryAccount data) { }
    }
}
