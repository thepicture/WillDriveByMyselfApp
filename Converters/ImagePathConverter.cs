﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace WillDriveByMyselfApp.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            return "..\\Resources\\" + value;
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