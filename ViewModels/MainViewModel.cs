using System.Windows.Input;
using WillDriveByMyselfApp.Commands;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isInAdminMode = false;

        public MainViewModel()
        {
            DependencyService.Get<INavigationService>().Navigated += OnNavigated;
            DependencyService.Get<IMessageService>().NewMessage += OnNewMessage;
        }

        private void OnNavigated()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
            OnPropertyChanged(nameof(CanGoBack));
        }
        private void OnNewMessage(object message)
        {
            if (message is string && (message as string) == "AdminModeEnable")
            {
                IsInAdminMode = true;
            }
        }

        public ViewModelBase SelectedViewModel => DependencyService
            .Get<INavigationService>().SelectedViewModel;
        public bool CanGoBack => DependencyService.Get<INavigationService>().CanGoBack;

        private RelayCommand _goToAdminModeCheckingCommand;

        public ICommand GoToAdminModeCheckingCommand
        {
            get
            {
                if (_goToAdminModeCheckingCommand == null)
                {
                    _goToAdminModeCheckingCommand =
                        new RelayCommand(GoToAdminModeChecking);
                }

                return _goToAdminModeCheckingCommand;
            }
        }

        private void GoToAdminModeChecking(object commandParameter)
        {
            DependencyService.Get<INavigationService>()
                .Navigate<AdminModeCheckingViewModel>();
        }

        private RelayCommand _goBackCommand;

        public ICommand GoBackCommand
        {
            get
            {
                if (_goBackCommand == null)
                {
                    _goBackCommand = new RelayCommand(GoBack);
                }

                return _goBackCommand;
            }
        }

        public bool IsInAdminMode
        {
            get => _isInAdminMode; set
            {
                _isInAdminMode = value;
                OnPropertyChanged();
            }
        }

        private void GoBack(object commandParameter)
        {
            DependencyService.Get<NavigationService>().GoBack();
        }
    }
}
