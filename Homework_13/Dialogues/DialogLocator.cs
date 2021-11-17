using Microsoft.Extensions.DependencyInjection;

namespace Homework_13.Dialogues
{
    /// <summary>
    /// 
    /// </summary>
    public class DialogLocator
    {
        /// <summary>
        /// 
        /// </summary>
        public BankCustomerInfoDialog BankCustomerInfoDialog => App.Host.Services.GetRequiredService<BankCustomerInfoDialog>();

        /// <summary>
        /// 
        /// </summary>
        public BankCustomerDialog BankCustomerDialog => App.Host.Services.GetRequiredService<BankCustomerDialog>();

        /// <summary>
        /// 
        /// </summary>
        public DepositoryAccountDialog DepositoryAccountDialog => App.Host.Services.GetRequiredService<DepositoryAccountDialog>();

        /// <summary>
        /// 
        /// </summary>
        public DepositoryAccountInfoDialog DepositoryAccountInfoDialog => App.Host.Services.GetRequiredService<DepositoryAccountInfoDialog>();

        /// <summary>
        /// 
        /// </summary>
        public FileDialog FileDialog => App.Host.Services.GetRequiredService<FileDialog>();

        /// <summary>
        /// 
        /// </summary>
        public FileIOService FileIOService => App.Host.Services.GetRequiredService<FileIOService>();
    }
}
