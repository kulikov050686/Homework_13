namespace Homework_13.Interfaces
{
    /// <summary>
    /// Обработка Счетов
    /// </summary>
    public interface IProcessingOfAccounts<T> where T: IBankAccount
    {
        void OpenAccount();

        void CloseAccount();

        void EditAccount();
    }
}
