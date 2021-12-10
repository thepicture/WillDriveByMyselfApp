﻿using System;
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
            return (double)value * 100;
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