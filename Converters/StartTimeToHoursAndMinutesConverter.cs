using System;
using System.Globalization;
using System.Windows.Data;

namespace WillDriveByMyselfApp.Converters
{
    public class StartTimeToHoursAndMinutesConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            DateTime startTime = (DateTime)value;
            TimeSpan differenceInOneDay = TimeSpan.FromDays(2) - startTime.TimeOfDay;
            string template = differenceInOneDay.TotalHours
                              + " часов "
                              + differenceInOneDay.TotalMinutes
                              + " минут";
            return template;
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
