using Homework_13.Enums;

namespace Homework_13.Infrastructure
{
    /// <summary>
    /// Обработчик событий репозитория
    /// </summary>
    /// <param name="args"> Действия в репозитории </param>
    public delegate void RepositoryEventHandler(RepositoryArgs args);
}
