﻿using Homework_13.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Homework_13.Services
{
    /// <summary>
    /// Базовый класс репозиторий 
    /// </summary>
    /// <typeparam name="T"> Тип хранимых сущностей </typeparam>
    abstract public class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        #region Закрытые поля

        private IList<T> _items = new ObservableCollection<T>();
        private int _lastId;

        #endregion

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected RepositoryInMemory()
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="items"> Список элементов </param>
        protected RepositoryInMemory(IList<T> items)
        {
            foreach (var item in items) Add(item);
        }
        
        /// <summary>
        /// Добавить в репозиторий
        /// </summary>
        /// <param name="item"> Добавляемый элемент </param>
        public void Add(T item)
        {
            if (item is null) 
                throw new ArgumentNullException(nameof(item));
            if (_items.Contains(item)) return;

            item.Id = ++_lastId;
            _items.Add(item);
        }

        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        /// <param name="id"> Идентифткатор </param>        
        public T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);        

        /// <summary>
        /// Получить все элементы
        /// </summary>        
        public IList<T> GetAll() => _items;

        /// <summary>
        /// Задать список сущностей в репозитории
        /// </summary>
        /// <param name="items"> Список сущностей  </param>
        public void SetAll(IList<T> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            _items.Clear();

            foreach (var item in items)
            {
                _items.Add(item);
            }

            _lastId = _items[_items.Count - 1].Id;
        }

        /// <summary>
        /// Удалить элемент из репозитория
        /// </summary>
        /// <param name="item"> Удаляемый элемент </param>        
        public bool Remove(T item) => _items.Remove(item);
        
        /// <summary>
        /// Обновление данных элемента
        /// </summary>
        /// <param name="id"> Идентификатор элемента </param>
        /// <param name="item"> Новые данные </param>
        public void Update(int id, T item)
        {
            if (item is null) 
                throw new ArgumentNullException(nameof(item));
            if (id <= 0) 
                throw new ArgumentOutOfRangeException(nameof(id), id, "Идентификатор неможет быть меньше 1");
            if (_items.Contains(item)) 
                return;

            var db_item = ((IRepository<T>)this).Get(id);

            if (db_item is null) 
                throw new InvalidOperationException("Редактируемый элемент не найден в репозитории");

            Update(item, db_item);
        }
        
        /// <summary>
        /// Обновление данных элемента
        /// </summary>
        /// <param name="source"> Новые данные </param>
        /// <param name="destination"> Обновляемый элемент </param>
        protected abstract void Update(T source, T destination);
    }
}
