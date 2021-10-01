﻿namespace Homework_13.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса диалоговых окон по работе с банковскими счетами
    /// </summary>
    public interface IBankAccountDialogService<T> where T: IBankAccount
    {
        /// <summary>
        /// Создание нового банковского счёта
        /// </summary>             
        T CreateNewBankAccount();

        /// <summary>
        /// Редактировать данные банковского счёта
        /// </summary>
        /// <param name="bankAccount"> Банковский счёт </param>        
        T EditBankAccountData(T bankAccount);
    }
}
