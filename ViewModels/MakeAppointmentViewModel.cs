using System;
using System.Collections.Generic;
using System.Windows.Input;
using WillDriveByMyselfApp.Commands;
using WillDriveByMyselfApp.Entities;

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
        }
    }
}
