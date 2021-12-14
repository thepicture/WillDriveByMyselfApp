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
            string inputFilePath = value as string;
            string[] filePath = inputFilePath.Split(
                new string[] { "\\" },
                StringSplitOptions.RemoveEmptyEntries);
            string fileNameOfFilePath = filePath[filePath.Length - 1];
            return fileNameOfFilePath;
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
