using Homework_13.Enums;

namespace Homework_13.Infrastructure
{
    /// <summary>
    /// Обработчик событий репозитория
    /// </summary>
    /// <param name="args"> Действия в репозитории </param>
    public delegate void RepositoryEventHandler(RepositoryArgs args);

    /// <summary>
    /// Обработчик события при действии со счетами
    /// </summary>
    /// <param name="sender"> Параметр события </param>
    /// <param name="args"> Действия со счетами </param>
    public delegate void ProcessingOfAccountsEventHandler(object sender, ProcessingOfAccountsArgs args);
}
