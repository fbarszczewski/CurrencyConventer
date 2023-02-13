using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CurrencyConventer.Core
{
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value!=null)
                return value.ToString();
            else
                return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double result;

            return double.TryParse(value.ToString(), out result) ? result : 0;
        }
    }

    public class LongToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                date = date.AddSeconds(double.Parse(value.ToString())).ToLocalTime();
                return date.ToString();
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
