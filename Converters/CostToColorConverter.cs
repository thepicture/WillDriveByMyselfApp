using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WillDriveByMyselfApp.Converters
{
    public class CostToColorConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            bool isDiscountPositive = (double)value > 0;
            return isDiscountPositive ? Brushes.LightGreen : Brushes.White;
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
