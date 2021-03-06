using Homework_13.Enums;
using System;
using System.Globalization;

namespace Homework_13.Converters
{
    public class GenderToTextConverter : BaseValueConverter<GenderToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Gender index)
            {
                switch (index)
                {
                    case Gender.MAN:
                        return "муж";
                    case Gender.WOMAN:
                        return "жен";
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
                    case "муж":
                        return Gender.MAN;
                    case "жен":
                        return Gender.WOMAN;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
