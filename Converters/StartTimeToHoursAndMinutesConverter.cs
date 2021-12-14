using System;
using System.Globalization;
using System.Windows.Data;

namespace WillDriveByMyselfApp.Converters
{
    public class StartTimeToHoursAndMinutesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime startTime = (DateTime)value;
            TimeSpan difference = TimeSpan.FromDays(1) - startTime.TimeOfDay;
            string template = difference.Hours
                              + " часов "
                              + difference.Minutes
                              + " минут";
            return template;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
