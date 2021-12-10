using System.Windows.Input;
using WillDriveByMyselfApp.Commands;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.ViewModels
{
    public class AdminModeCheckingViewModel : ViewModelBase
    {

        private string _code;

        public string Code
        {
            get => _code; set
            {
                _code = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _activateAdminModeCommand;

        public ICommand ActivateAdminModeCommand
        {
            get
            {
                if (_activateAdminModeCommand == null)
                {
                    _activateAdminModeCommand = new RelayCommand(ActivateAdminMode);
                }

                return _activateAdminModeCommand;
            }
        }

        private void ActivateAdminMode(object commandParameter)
        {
            if (Code == "0000")
            {
                DependencyService.Get<MessageBoxPopupService>().ShowInfo("Режим " +
                    "администратора активирован");
                DependencyService.Get<MessageService>().Send("AdminModeEnable");
                DependencyService.Get<NavigationService>().GoBack();
            }
            else
            {
                DependencyService.Get<MessageBoxPopupService>().ShowWarning("Неверный " +
                    "код. Введите корректный код для активации режима администратора");
            }
        }
    }
}
