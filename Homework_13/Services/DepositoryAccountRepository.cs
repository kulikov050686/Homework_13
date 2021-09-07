using Homework_13.Interfaces;
using Homework_13.Models;

namespace Homework_13.Services
{
    /// <summary>
    /// Хранилище депозитарных счетов
    /// </summary>
    public class DepositoryAccountRepository : RepositoryInMemory<IDepositoryAccount>
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DepositoryAccountRepository() : base(TestData.DepositoryAccounts) { }
                
        /// <summary>
        /// Обновление данных 
        /// </summary>
        /// <param name="source"> Новые данные </param>
        /// <param name="destination"> Обновляемые данные </param>
        protected override void Update(IDepositoryAccount source, IDepositoryAccount destination)
        {
            destination.Id = source.Id;            
            destination.Amount = source.Amount;
            destination.InterestRate = source.InterestRate;
            destination.DepositStatus = source.DepositStatus;
        }
    }
}
