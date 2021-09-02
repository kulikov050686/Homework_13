using Homework_13.Enums;
using System;
using System.Globalization;

namespace Homework_13.Converters
{
    public class IntToReliabilityConverter : BaseValueConverter<IntToReliabilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Reliability index)
            {
                switch (index)
                {
                    case Reliability.FIRST:
                        return 0;                        
                    case Reliability.SECOND:
                        return 1;                        
                    case Reliability.THIRD:
                        return 2;                        
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
                        return Reliability.FIRST;
                    case 1:
                        return Reliability.SECOND;
                    case 2:
                        return Reliability.THIRD;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
