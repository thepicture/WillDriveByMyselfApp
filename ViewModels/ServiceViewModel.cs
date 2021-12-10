using System.Collections.ObjectModel;
using WillDriveByMyselfApp.Entities;

namespace WillDriveByMyselfApp.ViewModels
{
    public class ServiceViewModel : ViewModelBase
    {
        private ObservableCollection<Service> _services;
        public ServiceViewModel()
        {
            Title = "Список услуг";
            Services = new ObservableCollection<Service>(ServiceStore.ReadAll());
        }

        public ObservableCollection<Service> Services
        {
            get => _services; set
            {
                _services = value;
                OnPropertyChanged();
            }
        }
    }
}
