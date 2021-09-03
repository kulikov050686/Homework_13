using Homework_13.Enums;
using System;
using System.Globalization;

namespace Homework_13.Converters
{
    public class ReliabilityToTextConverter : BaseValueConverter<ReliabilityToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Reliability index)
            {
                switch (index)
                {
                    case Reliability.FIRST:
                        return "Низкая";
                    case Reliability.SECOND:
                        return "Средняя";
                    case Reliability.THIRD:
                        return "Высокая";
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
                    case "Низкая":
                        return Reliability.FIRST;
                    case "Средняя":
                        return Reliability.SECOND;
                    case "Высокая":
                        return Reliability.THIRD;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
