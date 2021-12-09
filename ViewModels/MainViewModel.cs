using System.Windows.Input;
using WillDriveByMyselfApp.Commands;
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
            OnPropertyChanged(nameof(CanGoBack));
        }

        public ViewModelBase SelectedViewModel => NavigationService.SelectedViewModel;
        public bool CanGoBack => NavigationService.CanGoBack;

        private RelayCommand goToAdminModeCheckingCommand;

        public ICommand GoToAdminModeCheckingCommand
        {
            get
            {
                if (goToAdminModeCheckingCommand == null)
                {
                    goToAdminModeCheckingCommand = new RelayCommand(GoToAdminModeChecking);
                }

                return goToAdminModeCheckingCommand;
            }
        }

        private void GoToAdminModeChecking(object commandParameter)
        {
            NavigationService.Navigate<AdminModeCheckingViewModel>();
        }

        private RelayCommand goBackCommand;

        public ICommand GoBackCommand
        {
            get
            {
                if (goBackCommand == null)
                {
                    goBackCommand = new RelayCommand(GoBack);
                }

                return goBackCommand;
            }
        }

        private void GoBack(object commandParameter)
        {
            NavigationService.GoBack();
        }
    }
}
