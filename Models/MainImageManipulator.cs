using System;
using System.IO;

namespace WillDriveByMyselfApp.Models
{
    public class MainImageManipulator : IManipulator
    {
        private const string servicesPathPart = "Услуги автосервиса";
        private readonly string _imageFolderPath;

        public MainImageManipulator()
        {
            _imageFolderPath = Path.GetDirectoryName
             (
                 System.Reflection.Assembly.GetExecutingAssembly().CodeBase
             )
             .Replace("file:\\", "") + "\\..\\..\\Resources\\";
        }

        public void Add(object obj)
        {
            string sourcePhotoFilePath = obj as string;
            string fileName = GetFileName(sourcePhotoFilePath);
            File.Copy(sourcePhotoFilePath,
                      Path.Combine(_imageFolderPath, servicesPathPart, fileName),
                      overwrite: true);
        }

        private string GetFileName(string sourcePhotoFilePath)
        {
            string[] pathsArray = sourcePhotoFilePath.Split(new string[] { "\\" },
                StringSplitOptions.RemoveEmptyEntries);
            return pathsArray[pathsArray.Length - 1];
        }

        public object Get(object obj)
        {
            string fileName = obj as string ?? string.Empty;
            string photoFilePath = Path.Combine(_imageFolderPath,
                                                fileName);
            return File.Exists(photoFilePath)
                ? photoFilePath
                : Path.Combine(_imageFolderPath, "service_logo.png");
        }
    }
}
