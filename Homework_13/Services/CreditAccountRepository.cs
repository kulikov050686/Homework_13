using Homework_13.Interfaces;
using Homework_13.Models;

namespace Homework_13.Services
{
    /// <summary>
    /// Хранилище кредитных счетов
    /// </summary>
    public class CreditAccountRepository : RepositoryInMemory<ICreditAccount>
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public CreditAccountRepository() : base (TestData.CreditAccounts) { }

        /// <summary>
        /// Обновление данных 
        /// </summary>
        /// <param name="source"> Новые данные </param>
        /// <param name="destination"> Обновляемые данные </param>
        protected override void Update(ICreditAccount source, ICreditAccount destination)
        {
            destination.Id = source.Id;
            destination.Blocking = source.Blocking;
            destination.Amount = source.Amount;
            destination.InterestRate = source.InterestRate;
            destination.CreditTerm = source.CreditTerm;
            destination.CreditStatus = source.CreditStatus;
        }
    }
}
