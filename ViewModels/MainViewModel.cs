using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            NavigationService.Navigated += OnNavigated;
        }

        private void OnNavigated()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }

        public ViewModelBase SelectedViewModel => NavigationService.SelectedViewModel;
    }
}
