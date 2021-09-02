using Homework_13.Enums;
using Homework_13.Interfaces;
using Homework_13.Models;
using Homework_13.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_13.Services
{
    /// <summary>
    /// Класс сервиса диалоговых окон по работе с клиентом банка
    /// </summary>
    public class BankCustomerDialog : IBankCustomerDialogService
    {
        /// <summary>
        /// Создание нового клиента банка
        /// </summary>
        /// <param name="clientStatus"> Статус клиента банка </param>        
        public BankCustomer CreateNewBankCustomer(Status clientStatus)
        {
            var dialog = new AddBankCustomersWindow();

            if (dialog.ShowDialog() != true) return null;

            return null;
        }

        /// <summary>
        /// Редактировать данные клиента банка
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        public BankCustomer EditBankCustomerData(BankCustomer bankCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
