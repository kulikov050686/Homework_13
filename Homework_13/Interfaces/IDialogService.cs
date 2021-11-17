using System.Collections.Generic;

namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон по работе с сущностями
    /// </summary>    
    public interface IDialogService<T> where T: IEntity
    {
        /// <summary>
        /// Создать сущность
        /// </summary>        
        T Create();

        /// <summary>
        /// Редактировать сущность
        /// </summary>        
        T Edit(T entity);

        /// <summary>
        /// Выбрать сущность
        /// </summary>
        /// <param name="entities"> Список сущностей </param>        
        T Selected(IList<T> entities);
    }
}
