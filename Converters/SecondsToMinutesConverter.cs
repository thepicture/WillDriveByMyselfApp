using System;
using System.Globalization;
using System.Windows.Data;

namespace WillDriveByMyselfApp.Converters
{
    public class SecondsToMinutesConverter : IValueConverter
    {
        private const int ZeroSeconds = 0;

        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            double seconds = (int)value * 1.0;
            double minutes = Math.Floor(seconds / 60);
            return minutes;
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            bool isNoMinutesPresented = value == null
                                        || string.IsNullOrEmpty((string)value);
            if (isNoMinutesPresented)
            {
                return ZeroSeconds;
            }
            double minutes = (double)value;
            return System.Convert.ToInt32(minutes * 60);
        }
    }
}
