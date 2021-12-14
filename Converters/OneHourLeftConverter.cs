﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WillDriveByMyselfApp.Converters
{
    public class OneHourLeftConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            return DateTime.Now.Subtract((DateTime)value) < TimeSpan.FromHours(1)
            ? Brushes.Red
            : Brushes.White;
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
