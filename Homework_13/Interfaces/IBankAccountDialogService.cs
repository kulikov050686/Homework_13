namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон по работе с банковскими счетами
    /// </summary>
    public interface IBankAccountDialogService<T> : IDialogService<T> where T: IBankAccount
    {
        /// <summary>
        /// Создать банковский счёт
        /// </summary>        
        T Create();
    }
}
