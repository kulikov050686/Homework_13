using Homework_13.Enums;

namespace Homework_13.Infrastructure
{
    /// <summary>
    /// Обработчик событий репозитория
    /// </summary>
    /// <param name="sender"> Параметр события </param>
    /// <param name="args"> Действия в репозитории </param>
    public delegate void RepositoryEventHandler(object sender, RepositoryArgs args);

    /// <summary>
    /// Обработчик событий менеджера
    /// </summary>
    /// <param name="sender"> Параметр события </param>
    /// <param name="args"> Действия менеджера </param>
    public delegate void ManagerEventHandler(object sender, ManagerArgs args);

    /// <summary>
    /// Обработчик события при действии со счетами
    /// </summary>
    /// <param name="sender"> Параметр события </param>
    /// <param name="args"> Действия со счетами </param>
    public delegate void ProcessingOfAccountsEventHandler(object sender, ProcessingOfAccountsArgs args);
}
