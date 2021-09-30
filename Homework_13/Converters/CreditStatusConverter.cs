using Homework_13.Enums;
using System;
using System.Globalization;

namespace Homework_13.Converters
{
    public class CreditStatusConverter : BaseValueConverter<CreditStatusConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is CreditStatus index)
            {
                switch (index)
                {
                    case CreditStatus.ANNUITY:
                        return 0;
                    case CreditStatus.DIFFERENTIATED:
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
                        return CreditStatus.ANNUITY;
                    case 1:
                        return CreditStatus.DIFFERENTIATED;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
