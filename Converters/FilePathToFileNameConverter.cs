using System;
using System.Globalization;
using System.Windows.Data;

namespace WillDriveByMyselfApp.Converters
{
    public class FilePathToFileNameConverter : IValueConverter
    {
        public object Convert(string value)
        {
            return Convert(value, null, null, null);
        }
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            string[] filePath = (value as string).Split(new string[] { "\\" },
                                                        StringSplitOptions.RemoveEmptyEntries);
            return filePath[filePath.Length - 1];
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
