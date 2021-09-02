using Homework_13.Enums;
using System;
using System.Globalization;

namespace Homework_13.Converters
{
    public class IntToGenderConverter : BaseValueConverter<IntToGenderConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Gender index)
            {
                switch (index)
                {
                    case Gender.MAN:
                        return 0;
                    case Gender.WOMAN:
                        return 1;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                switch (index)
                {
                    case 0:
                        return Gender.MAN;
                    case 1:
                        return Gender.WOMAN;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
