using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Homework_13.Models
{
    /// <summary>
    /// Тестовые данные
    /// </summary>
    public static class TestData
    {
        /// <summary>
        /// Департаменты банка
        /// </summary>
        public static IList<IDepartment> Departments { get; set; } = CreateDepartments();

        /// <summary>
        /// Клиенты банка
        /// </summary>
        public static IList<IBankCustomer> BankCustomers { get; set; } = CreateBankCustomers(Departments);

        /// <summary>
        /// Депозитарные счета клиентов банка
        /// </summary>
        public static IList<IDepositoryAccount> DepositoryAccounts { get; set; } = CreateDepositoryAccounts(BankCustomers);

        /// <summary>
        /// Создание департаментов банка
        /// </summary>        
        public static IList<IDepartment> CreateDepartments()
        {
            ObservableCollection<IDepartment> departments = new ObservableCollection<IDepartment>();

            departments.Add(new Department(1, $"Департамент { 1 }", Status.USUAL));
            departments.Add(new Department(2, $"Департамент { 2 }", Status.VIP));
            departments.Add(new Department(3, $"Департамент { 3 }", Status.JURIDICAL));
            
            return departments;
        }
        
        /// <summary>
        /// Заполнение клиентами банка депортаментов
        /// </summary>
        /// <param name="departments"> Департаменты </param>
        private static IList<IBankCustomer> CreateBankCustomers(IList<IDepartment> departments)
        {
            var index = 1;
            var gender = Gender.MAN;
            var reliability = Reliability.FIRST;

            foreach (var item in departments)
            {
                for (int i = 0; i < 10; i++)
                {
                    if(i % 2 == 0)
                    {
                        gender = Gender.WOMAN;
                        reliability = Reliability.FIRST;
                    }
                    else
                    {
                        gender = Gender.MAN;
                        reliability = Reliability.SECOND;
                    }

                    var address = new Address(DateTime.Today, $"Регион {index}", $"Город {index}", $"Улица {index}", 100 + index);
                    var person = new Person($"Фамилия {index}", $"Имя {index}", $"Отчество {index}", gender, DateTime.Today, $"Место рождения {index}", address);
                    var divisionCode = new DivisionCode(200 + index, 300 + index);
                    var pasport = new Passport(111, 222222, $"Место выдачи {index}", DateTime.Today, divisionCode, person);

                    var bankCustomer = new BankCustomer(index, pasport, item.StatusDepartment, reliability, $"0123-456-789");

                    item.BankCustomers.Add(bankCustomer);
                    index++;
                }
            }
            
            return departments.SelectMany(d => d.BankCustomers).ToList();            
        }

        /// <summary>
        /// Заполнение депозитарными счетами клиентов банка
        /// </summary>
        /// <param name="bankCustomers"> Клиенты банка </param>
        private static IList<IDepositoryAccount> CreateDepositoryAccounts(IList<IBankCustomer> bankCustomers)
        {
            var index = 1;
            bool key = false;
            DepositoryAccount bankAccount;

            foreach (var item in bankCustomers)
            {
                for(int i = 0; i < 4; i++)
                {
                    if (key)
                    {
                        bankAccount = new DepositoryAccount(index, 1000, InterestRate(item.ClientStatus), DepositStatus.WITHOUTCAPITALIZATION);                        
                        key = !key;
                    }
                    else
                    {
                        bankAccount = new DepositoryAccount(index, 2000, InterestRate(item.ClientStatus), DepositStatus.WITHCAPITALIZATION);                        
                        key = !key;
                    }

                    item.DepositoryAccounts.Add(bankAccount);
                    index++;
                }
            }
                        
            return bankCustomers.SelectMany(d => d.DepositoryAccounts).ToList();                       
        }

        /// <summary>
        /// Процентная ставка депозитарного счёта
        /// </summary>
        /// <param name="status"> Статус </param>        
        private static double InterestRate(Status status)
        {
            if (status == Status.VIP)
                return 10;
            if (status == Status.JURIDICAL)
                return 8;
            
            return 12;
        }
    }
}
