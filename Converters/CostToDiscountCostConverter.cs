using System;
using System.Globalization;
using System.Windows.Data;
using WillDriveByMyselfApp.Entities;

namespace WillDriveByMyselfApp.Converters
{
    public class CostToDiscountCostConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            Service service = value as Service;
            if (service == null || service.Discount == null || service.Cost == 0)
            {
                return 0;
            }
            double? discountCoefficient = 1 - service.Discount;
            return (double)service.Cost * (double)discountCoefficient;
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
