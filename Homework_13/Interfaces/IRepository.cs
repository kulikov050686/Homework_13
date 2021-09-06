﻿using System.Collections.Generic;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс репозиторий
    /// </summary>
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Добавить сущность в репозиторий
        /// </summary>
        /// <param name="item"> Добавляемая сущность </param>
        void Add(T item);

        /// <summary>
        /// Удаление сущности из репозитория
        /// </summary>
        /// <param name="item"> Удаляемая сущность </param>
        bool Remove(T item);

        /// <summary>
        /// Обновление сущности в репозитории
        /// </summary>
        /// <param name="item"> Обноляемая сущность </param>
        void Update(int id, T item);

        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор сущности </param>
        T Get(int id);

        /// <summary>
        /// Получить все сущности
        /// </summary>
        IList<T> GetAll();
    }
}
