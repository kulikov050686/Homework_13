namespace Homework_13.Enums
{
    /// <summary>
    /// Действия со счетами
    /// </summary>
    public enum ProcessingOfAccountsArgs : byte
    {
        /// <summary>
        /// Открыть счёт
        /// </summary>
        OPEN = 0,

        /// <summary>
        /// Закрыть счёт
        /// </summary>
        CLOSE = 1,

        /// <summary>
        /// Редактировать счёт
        /// </summary>
        EDIT = 2,

        /// <summary>
        /// Объединить счета
        /// </summary>
        COMBINING = 3,

        /// <summary>
        /// Перевести на счёт
        /// </summary>
        TRANSFER = 4,

        /// <summary>
        /// Вывести со счёта
        /// </summary>
        WITHDRAW = 5,

        /// <summary>
        /// Блокировать счёт
        /// </summary>
        BLOCK = 6,

        /// <summary>
        /// Разблокировать счёт
        /// </summary>
        UNBLOCK = 7
    }
}
