using Microsoft.Win32;

namespace WillDriveByMyselfApp.Services
{
    public class OpenFileDialogService : IDialogService
    {
        private readonly OpenFileDialog _fileDialog;

        public OpenFileDialogService()
        {
            _fileDialog = new OpenFileDialog();
        }

        public object GetResult()
        {
            return _fileDialog.FileName;
        }

        public string GetFileNameOnly()
        {
            return _fileDialog.SafeFileName;
        }

        public bool IsDialogOpened()
        {
            return (bool)_fileDialog.ShowDialog();
        }
    }
}
