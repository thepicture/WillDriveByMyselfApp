using System;
using System.Globalization;
using System.Windows.Data;

namespace WillDriveByMyselfApp.Converters
{
    public class DiscountToPercentConverter : IValueConverter
    {
        private const int NoDiscount = 0;

        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            bool isDiscountNotProvided = value is null;
            double discount = (double)value;
            double discountPercent = discount * 100;
            return isDiscountNotProvided
                ? NoDiscount
                : discountPercent;
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            bool isDiscountNotProvided = string.IsNullOrEmpty((string)value);
            object discountCoefficient = double.Parse((string)value) / 100;
            return isDiscountNotProvided
                ? NoDiscount
                : discountCoefficient;
        }
    }
}
