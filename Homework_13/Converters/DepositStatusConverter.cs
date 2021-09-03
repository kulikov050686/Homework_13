using Homework_13.Enums;
using System;
using System.Globalization;

namespace Homework_13.Converters
{
    public class DepositStatusConverter : BaseValueConverter<DepositStatusConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DepositStatus index)
            {
                switch (index)
                {
                    case DepositStatus.WITHOUTCAPITALIZATION:
                        return 0;
                    case DepositStatus.WITHCAPITALIZATION:
                        return 1;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int index)
            {
                switch (index)
                {
                    case 0:
                        return DepositStatus.WITHOUTCAPITALIZATION;
                    case 1:
                        return DepositStatus.WITHCAPITALIZATION;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
