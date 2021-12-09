namespace WillDriveByMyselfApp.Services
{
    public interface IMessageService
    {
        void ShowInfo(string message);
        void ShowWarning(string message);
        void ShowError(string message);
        bool ShowQuestion(string message);
    }
}
