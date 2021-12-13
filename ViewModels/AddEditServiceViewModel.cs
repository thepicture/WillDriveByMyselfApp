using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public Models.IManipulator ManipulatorService = DependencyService.Get<Models.IManipulator>();
        private string _validationErrors = string.Empty;

        public AddEditServiceViewModel(Service service)
        {
            if (service.ID == 0)
            {
                Title = "Добавление услуги";
                service.Discount = 0;
            }
            else
            {
                Title = "Редактирование услуги " + service.Title;
            }

            Service = service;
            PropertyChanged += SaveChangesCommand.ChangeCanExecute;
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
                ManipulatorService.Add(DialogService.GetResult());
                Service.MainImagePath = "Услуги автосервиса\\"
                                        + (string)new Converters.FilePathToFileNameConverter().Convert(DialogService.GetResult() as string);
                OnPropertyChanged(nameof(Service));
                DependencyService.Get<IPopupService>().ShowInfo("Изображение " +
                    "успешно изменено");
            }
        }

        private RelayCommand saveChangesCommand;

        public RelayCommand SaveChangesCommand
        {
            get
            {
                if (saveChangesCommand == null)
                {
                    saveChangesCommand = new RelayCommand(SaveChanges, CanSaveChangesExecute);
                }

                return saveChangesCommand;
            }
        }

        public string ValidationErrors
        {
            get => _validationErrors; set
            {
                _validationErrors = value;
                OnPropertyChanged();
            }
        }

        private bool CanSaveChangesExecute(object arg)
        {
            bool isValid = true;
            StringBuilder errors = new StringBuilder();
            if (Service.Title == null || Service.Title.Length == 0)
            {
                errors.AppendLine("Название услуги должно быть указано");
                isValid = false;
            }
            if (Service.Cost <= 0)
            {
                errors.AppendLine("Стоимость услуги - это натуральное число");
                isValid = false;
            }
            if (Service.DurationInSeconds <= 0)
            {
                errors.AppendLine("Длительность услуги - " +
                    "это натуральное число в минутах");
                isValid = false;
            }
            if (Service.Discount < 0)
            {
                errors.AppendLine("Скидка услуги - " +
                    "это неотрицательное натуральное число");
                isValid = false;
            }
            ValidationErrors = errors.ToString();
            return isValid;
        }

        private async void SaveChanges(object commandParameter)
        {
            IEnumerable<Service> services = await ServiceStore.ReadAllAsync();
            if (services.Any(s => s.Title.ToLower().Equals(Service.Title.ToLower())))
            {
                DependencyService.Get<IPopupService>().ShowWarning("Добавление " +
                    "услуги невозможно. Такая услуга существует в системе. " +
                    "Названия у услуг не должны быть одинаковы. " +
                    "Измените название услуги и попробуйте ещё раз");
                return;
            }
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
