using Homework_13.Enums;
using System;
using System.Globalization;

namespace Homework_13.Converters
{
    public class GenderToTextConverter : BaseValueConverter<GenderToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Gender)value == Gender.MAN) return "муж";
            if ((Gender)value == Gender.WOMAN) return "жен";

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
