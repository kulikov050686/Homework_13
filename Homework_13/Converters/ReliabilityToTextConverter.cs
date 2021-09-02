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
                        return "Надёжность низкая";
                    case Reliability.SECOND:
                        return "Надёжность средняя";
                    case Reliability.THIRD:
                        return "Надёжность высокая";
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
                    case "Надёжность низкая":
                        return Reliability.FIRST;
                    case "Надёжность средняя":
                        return Reliability.SECOND;
                    case "Надёжность высокая":
                        return Reliability.THIRD;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
