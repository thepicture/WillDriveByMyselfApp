using System.Windows.Input;
using WillDriveByMyselfApp.Commands;

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

        private RelayCommand activateAdminModeCommand;

        public ICommand ActivateAdminModeCommand
        {
            get
            {
                if (activateAdminModeCommand == null)
                {
                    activateAdminModeCommand = new RelayCommand(ActivateAdminMode);
                }

                return activateAdminModeCommand;
            }
        }

        private void ActivateAdminMode(object commandParameter)
        {
        }
    }
}
