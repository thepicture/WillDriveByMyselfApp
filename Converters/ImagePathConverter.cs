using System;
using System.Globalization;
using System.Windows.Data;
using WillDriveByMyselfApp.Models;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            return DependencyService.Get<IManipulator>().Get(value);
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
