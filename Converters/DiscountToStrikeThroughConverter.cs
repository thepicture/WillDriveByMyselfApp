using System;
using System.Globalization;
using System.Windows.Data;

namespace WillDriveByMyselfApp.Converters
{
    public class DiscountToStrikethroughConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            bool noDiscountProvided = value is null;
            if (noDiscountProvided)
            {
                return NoStrikethrough();
            }
            bool isDiscountPositive = (double)value > 0;
            return isDiscountPositive ? "Strikethrough" : null;
        }

        private static object NoStrikethrough()
        {
            return null;
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            return null;
        }
    }
}
