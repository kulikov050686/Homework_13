using Homework_13.Interfaces;
using System.IO;
using System;
using Homework_13.Enums;

namespace Homework_13.Services
{
    /// <summary>
    /// Класс журнала для клиентов банка
    /// </summary>
    public class ActionLogBankCustomers 
    {
        /// <summary>
        /// Добавить запись в журнал
        /// </summary> 
        /// <param name="nameFile"> Название файла журнала </param>
        /// <param name="data"> Данные для записи в журнал </param>
        /// <param name="args"> Аргументы </param>
        public void AddAnEntry(string nameFile, IBankCustomer data, ManagerArgs args)
        {
            if (string.IsNullOrWhiteSpace(nameFile) || data is null)
                throw new ArgumentNullException();

            string path = Directory.GetCurrentDirectory() + $"\\{nameFile}";

            try
            {
                if (Path.GetExtension(path) == ".txt")
                {
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        switch (args)
                        {
                            case ManagerArgs.CREATE:
                                Record(sw, data, "Создан");
                                break;
                            case ManagerArgs.UPDATE:
                                Record(sw, data, "Обновлён");
                                break;
                            case ManagerArgs.DELETE:
                                Record(sw, data, "Удалён");
                                break;                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArithmeticException(ex.Message);
            }
        }

        private void Record(StreamWriter sw, IBankCustomer data, string text) 
        {
            sw.WriteLine($"Статус: {text}");
            sw.WriteLine($"Имя: {data.Passport.Holder.Name}");
            sw.WriteLine($"Фамилия: {data.Passport.Holder.Surname}");
            sw.WriteLine($"Отчество: {data.Passport.Holder.Patronymic}");
            sw.WriteLine($"Дата рождения: {data.Passport.Holder.Birthday.ToString()}");
            sw.WriteLine("---------------------------------------------------------------------------");
        }
    }
}
