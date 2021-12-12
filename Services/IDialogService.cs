namespace WillDriveByMyselfApp.Services
{
    public interface IDialogService
    {
        bool IsDialogOpened();
        object GetResult();
    }
}
