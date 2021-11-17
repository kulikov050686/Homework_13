using Homework_13.Enums;
using Homework_13.Interfaces;
using Homework_13.Views;
using System.Windows.Media;

namespace Homework_13.Dialogues
{
    /// <summary>
    /// 
    /// </summary>
    public class BankCustomerInfoDialog : IInformationDialog<IBankCustomer>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Dialog(IBankCustomer data, ManagerArgs args)
        {
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
