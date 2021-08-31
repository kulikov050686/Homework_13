using Homework_13.Enums;
using System;
using System.Globalization;

namespace Homework_13.Converters
{
    public class ReliabilityToTextConverter : BaseValueConverter<ReliabilityToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Reliability)value)
            {
                case Reliability.FIRST:
                    return "Надёжность низкая";
                case Reliability.SECOND:
                    return "Надёжность средняя";
                default:
                    return "Надёжность высокая";
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
