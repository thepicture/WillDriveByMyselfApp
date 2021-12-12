using System;
using System.Globalization;
using System.Windows.Data;

namespace WillDriveByMyselfApp.Converters
{
    public class SecondsToMinutesConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            return Math.Floor((int)value * 1.0 / 60);
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
            return System.Convert.ToInt32(double.Parse((string)value) * 60);
        }
    }
}
