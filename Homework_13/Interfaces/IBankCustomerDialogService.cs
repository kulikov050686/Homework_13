using Homework_13.Enums;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон по работе с клиентом банка
    /// </summary>
    public interface IBankCustomerDialogService
    {
        /// <summary>
        /// Создание нового клиента банка
        /// </summary>
        /// <param name="clientStatus"> Статус клиента банка </param>        
        IBankCustomer CreateNewBankCustomer(Status clientStatus);
        
        /// <summary>
        /// Редактировать данные клиента банка
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        IBankCustomer EditBankCustomerData(IBankCustomer bankCustomer);
    }
}
