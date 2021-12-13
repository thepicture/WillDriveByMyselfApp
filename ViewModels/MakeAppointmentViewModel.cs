using System;
using System.Collections.Generic;
using System.Text;
using WillDriveByMyselfApp.Commands;
using WillDriveByMyselfApp.Entities;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.ViewModels
{
    public class MakeAppointmentViewModel : ViewModelBase
    {
        private Service _service;
        private Client _currentClient;
        public IEnumerable<Client> Clients { get; private set; }
        public MakeAppointmentViewModel(Service service)
        {
            Title = "Запись клиента на услугу " + service.Title;
            Service = service;
            LoadClients();
            PropertyChanged += SaveChangesCommand.ChangeCanExecute;
        }

        private async void LoadClients()
        {
            Clients = await ClientStore.ReadAllAsync();
        }

        private string _validationErrors;
        public string ValidationErrors
        {
            get => _validationErrors; set
            {
                _validationErrors = value;
                OnPropertyChanged();
            }
        }

        public Service Service
        {
            get => _service; set
            {
                _service = value;
                OnPropertyChanged();
            }
        }

        public Client CurrentClient
        {
            get => _currentClient; set
            {
                _currentClient = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _currentDate = DateTime.Now;

        public DateTime? CurrentDate
        {
            get => _currentDate; set
            {
                _currentDate = value;
                OnPropertyChanged();
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

        private bool CanSaveChangesExecute(object arg)
        {
            bool isValid = true;
            StringBuilder errors = new StringBuilder();
            if (!TimeSpan.TryParse(Time, out _))
            {
                _ = errors.AppendLine("Время начала окончания услуги некорректно,  " +
                    "введите корректное время в формате ЧЧ:ММ");
            }
            if (CurrentClient == null)
            {
                _ = errors.AppendLine("Не указан клиент в выпадающем списке");
            }
            if (CurrentDate == null)
            {
                _ = errors.AppendLine("Не указана дата");
            }
            if (Time != null && Time.Length != 5)
            {
                _ = errors.AppendLine("Время должно быть длиной в пять символов");
            }
            bool isErrorBuiderIsNotEmpty = errors.Length > 0;
            if (isErrorBuiderIsNotEmpty)
            {
                isValid = false;
                ValidationErrors = errors.ToString();
            }
            else
            {
                ValidationErrors = string.Empty;
            }
            return isValid;
        }

        private void SaveChanges(object commandParameter)
        {
            WillDriveByMyselfBaseEntities context = new WillDriveByMyselfBaseEntities();
            _ = CurrentDate.Value.Add(TimeSpan.Parse(Time));
            ClientService appointment = new ClientService
            {
                Client = context.Client.Find(CurrentClient.ID),
                Service = context.Service.Find(Service.ID),
                StartTime = CurrentDate.Value
            };
            _ = context.ClientService.Add(appointment);
            try
            {
                _ = context.SaveChanges();
                DependencyService.Get<IPopupService>().ShowInfo("Клиент " +
                    "успешно записан на услугу");
                DependencyService.Get<INavigationService>().GoBack();
            }
            catch (Exception ex)
            {
                DependencyService.Get<IPopupService>().ShowError("Не удалось " +
                    "записать клиента на услугу. Попробуйте ещё раз");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private string _time;

        public string Time
        {
            get => _time; set
            {
                _time = value;
                OnPropertyChanged();
            }
        }
    }
}
