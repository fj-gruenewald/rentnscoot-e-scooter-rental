using System;
using System.Globalization;
using System.Windows.Data;

namespace RentNScoot.Presentation.Converters
{
    internal class CDoNothingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;  // Only for seting a break point
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}