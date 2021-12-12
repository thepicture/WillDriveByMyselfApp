using System.Windows.Input;
using WillDriveByMyselfApp.Commands;
using WillDriveByMyselfApp.Entities;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.ViewModels
{
    public class AddEditServiceViewModel : ViewModelBase
    {
        private Service _service;
        public IDialogService DialogService = DependencyService.Get<IDialogService>();

        public AddEditServiceViewModel(Service service)
        {
            Title = service.ID == 0
                ? "Добавление услуги"
                : "Редактирование услуги " + service.Title;
            Service = service;
        }

        public Service Service
        {
            get => _service; set
            {
                _service = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand defineMainImagePathCommand;

        public ICommand DefineMainImagePathCommand
        {
            get
            {
                if (defineMainImagePathCommand == null)
                {
                    defineMainImagePathCommand = new RelayCommand(DefineMainImagePath);
                }

                return defineMainImagePathCommand;
            }
        }

        private void DefineMainImagePath(object commandParameter)
        {
            if (DialogService.IsDialogOpened())
            {

            }
        }

        private RelayCommand saveChangesCommand;

        public ICommand SaveChangesCommand
        {
            get
            {
                if (saveChangesCommand == null)
                {
                    saveChangesCommand = new RelayCommand(SaveChanges);
                }

                return saveChangesCommand;
            }
        }

        private void SaveChanges(object commandParameter)
        {
            bool serviceIsNew = Service.ID == 0;
            if (serviceIsNew)
            {
                ServiceStore.Create(Service);
            }
            else
            {
                ServiceStore.Update(Service);
            }
            if (ServiceStore.IsLastOperationSuccessful)
            {
                DependencyService.Get<NavigationService>().GoBack();
            }
        }
    }
}
