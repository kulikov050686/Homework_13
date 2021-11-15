using Homework_13.Enums;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон по работе с клиентом банка
    /// </summary>
    public interface IBankCustomerDialogService : IDialogService<IBankCustomer>
    {
        /// <summary>
        /// Создание нового клиента банка
        /// </summary>
        /// <param name="clientStatus"> Статус клиента банка </param>        
        IBankCustomer Create(Status clientStatus);
    }
}
