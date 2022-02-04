using System;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Data;

namespace RentNScoot.Presentation.Converters
{
    internal class CDoubleToCurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.ToString());

            // single value
            if (!(value is IEnumerable))
            {
                return ConvertItem(value, culture);
            }
            // collection
            else
            {
                var values = value as IEnumerable;
                var results = new ArrayList();
                foreach (var val in values!)
                {
                    results.Add(ConvertItem(val!, culture));
                }
                return results;
            }
        }

        private static object ConvertItem(object value, CultureInfo culture)
        {
            string sValue = value.ToString() ?? "";
            if (!double.TryParse(sValue, out double num)) num = 0.0;
            return string.Format(culture, "{0:C2}", num);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.ToString());
            string sValue = value?.ToString() ?? "";
            if (!double.TryParse(sValue, NumberStyles.Currency, culture, out double number)) number = 0;
            return number;
        }
    }
}