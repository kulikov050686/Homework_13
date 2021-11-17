using Homework_13.Enums;
using Homework_13.Interfaces;
using Homework_13.Views;
using System.Windows.Media;

namespace Homework_13.Dialogues
{
    /// <summary>
    /// Класс сервиса диалоговых окон по информированию о клиенте банка
    /// </summary>
    public class BankCustomerInfoDialog : IInformationDialog<IBankCustomer>
    {
        /// <summary>
        /// Диалог информации о клиенте банка
        /// </summary>
        /// <param name="data"> Клиент банка </param>
        /// <param name="args"> Действия с клиентом банка </param>
        public void Dialog(IBankCustomer data, ManagerArgs args)
        {
            if (data is null) return;
            var dialog = new InfoWindow();

            switch (args)
            {
                case ManagerArgs.CREATE:
                    dialog.ColorBackground = Brushes.Green;
                    dialog.MessageText = $"Добавлен новый клиент банка\n " +
                                         $"Имя:{data.Passport.Holder.Name}\n" +
                                         $"Фамилия: {data.Passport.Holder.Surname}\n";
                    break;
                case ManagerArgs.UPDATE:
                    dialog.ColorBackground = Brushes.Blue;
                    dialog.MessageText = $"Внесены изменения клиента банка\n" +
                                         $"Имя:{data.Passport.Holder.Name}\n" +
                                         $"Фамилия: {data.Passport.Holder.Surname}\n";
                    break;
                case ManagerArgs.DELETE:
                    dialog.ColorBackground = Brushes.Red;
                    dialog.MessageText = $"Удалён клиент банка\n" +
                                         $"Имя: {data.Passport.Holder.Name}\n" +
                                         $"Фамилия: {data.Passport.Holder.Surname}\n";
                    break;
            }

            dialog.Show();
            dialog.Close();
        }

        void IInformationDialog<IBankCustomer>.Dialog(IBankCustomer data) { }
    }
}
