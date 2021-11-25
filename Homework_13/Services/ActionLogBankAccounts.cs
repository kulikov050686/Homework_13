using Homework_13.Enums;
using Homework_13.Interfaces;
using System;
using System.IO;

namespace Homework_13.Services
{
    /// <summary>
    /// Класс журнала для банковских счетов
    /// </summary>
    public class ActionLogBankAccounts
    {
        /// <summary>
        /// Добавить запись в журнал
        /// </summary>
        /// <param name="nameFile"> Название файла журнала </param>
        /// <param name="data"> Данные для записи в журнал </param>
        /// <param name="args"> Аргументы </param>
        public void AddAnEntry(string nameFile, IBankAccount data, ProcessingOfAccountsArgs args)
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
                            case ProcessingOfAccountsArgs.OPEN:
                                Record(sw, data, "Счёт открыт");
                                break;
                            case ProcessingOfAccountsArgs.CLOSE:
                                Record(sw, data, "Счёт закрыт");
                                break;
                            case ProcessingOfAccountsArgs.EDIT:
                                Record(sw, data, "Счёт отредактирован");
                                break;
                            case ProcessingOfAccountsArgs.COMBINING:
                                Record(sw, data, "Счёта объединены");
                                break;
                            case ProcessingOfAccountsArgs.TRANSFER:
                                Record(sw, data, "Перевод на счёт");
                                break;
                            case ProcessingOfAccountsArgs.WITHDRAW:
                                Record(sw, data, "Переод со счёта");
                                break;
                            case ProcessingOfAccountsArgs.BLOCK:
                                Record(sw, data, "Счёт заблокирован");
                                break;
                            case ProcessingOfAccountsArgs.UNBLOCK:
                                Record(sw, data, "Счёт разблокировать");
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

        private void Record(StreamWriter sw, IBankAccount data, string text)
        {
            sw.WriteLine($"Статус: {text}");
            sw.WriteLine($"Сумма: {data.Amount}");
            sw.WriteLine($"Процентная ставка: {data.InterestRate}");
            sw.WriteLine("---------------------------------------------------------------------------");
        }
    }
}
