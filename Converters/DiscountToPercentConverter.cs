using System;
using System.Globalization;
using System.Windows.Data;

namespace WillDriveByMyselfApp.Converters
{
    public class DiscountToPercentConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            return value is null
                ? 0
                : (double)value * 100;
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return 0;
            }
            return double.Parse((string)value) / 100;
        }
    }
}
