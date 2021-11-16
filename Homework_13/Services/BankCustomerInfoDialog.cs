using Homework_13.Interfaces;
using Homework_13.Views;

namespace Homework_13.Services
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
        public void Dialog(IBankCustomer data)
        {
            var dialog = new InfoWindow();
            dialog.Show();
            dialog.Close();
        }
    }
}
