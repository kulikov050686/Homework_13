using Homework_13.Enums;
using System;
using System.Globalization;

namespace Homework_13.Converters
{
    public class CreditStatusToTextConverter : BaseValueConverter<CreditStatusToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is CreditStatus index)
            {
                switch (index)
                {
                    case CreditStatus.ANNUITY:
                        return "Ануитет";                        
                    case CreditStatus.DIFFERENTIATED:
                        return "Дифференцированный";
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string index)
            {
                switch (index)
                {
                    case "Ануитет":
                        return CreditStatus.ANNUITY;
                    case "Дифференцированный":
                        return CreditStatus.DIFFERENTIATED;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
