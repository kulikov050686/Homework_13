using Microsoft.Extensions.DependencyInjection;

namespace Homework_13.Dialogues
{
    /// <summary>
    /// Класс для доступа к конкретным диалоговым окнам
    /// </summary>
    public class DialogLocator
    {
        /// <summary>
        /// Сервиса диалоговых окон по информированию о клиенте банка
        /// </summary>
        public BankCustomerInfoDialog BankCustomerInfoDialog => App.Host.Services.GetRequiredService<BankCustomerInfoDialog>();

        /// <summary>
        /// Сервис диалоговых окон по работе с клиентом банка
        /// </summary>
        public BankCustomerDialog BankCustomerDialog => App.Host.Services.GetRequiredService<BankCustomerDialog>();

        /// <summary>
        /// Cервис диалоговых окон по работе с депозитарными счетами
        /// </summary>
        public DepositoryAccountDialog DepositoryAccountDialog => App.Host.Services.GetRequiredService<DepositoryAccountDialog>();

        /// <summary>
        /// Сервиса диалоговых окон по информированию о дипозитарном счёте
        /// </summary>
        public DepositoryAccountInfoDialog DepositoryAccountInfoDialog => App.Host.Services.GetRequiredService<DepositoryAccountInfoDialog>();

        /// <summary>
        /// Сервис диалоговых окон по сохранению и выгрузки данных из файла
        /// </summary>
        public FileDialog FileDialog => App.Host.Services.GetRequiredService<FileDialog>();
    }
}
