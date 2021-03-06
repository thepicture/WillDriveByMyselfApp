using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WillDriveByMyselfApp.Commands;
using WillDriveByMyselfApp.Entities;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.ViewModels
{
    public class ServiceViewModel : ViewModelBase
    {
        private const double percentToCoefficientFactor = 0.01;
        private IEnumerable<Service> _services;
        private IEnumerable<string> _sortTypes;
        private string _currentSortType;
        private IEnumerable<string> _filterTypes;
        private string _currentFilterType;
        private string _titleSearchText = string.Empty;
        private string _descriptionSearchText = string.Empty;
        private ICommand _deleteServiceCommand;
        public ICommand MakeAppointmentCommand { get; }
        public ICommand EditServiceCommand => new RelayCommand(EditService);

        private void EditService(object obj)
        {
            Service service = obj as Service;
            DependencyService.Get<INavigationService>().Navigate<AddEditServiceViewModel>(service);
        }

        public ServiceViewModel()
        {
            Title = "Список услуг";
            _ = Task.Run(() =>
              {
                  SortTypes = new List<string>
              {
                "Без сортировки",
                "По стоимости по возрастанию",
                "По стоимости по убыванию",
              };
                  CurrentSortType = SortTypes.First();
                  FilterTypes = new List<string>
              {
                "Все",
                "от 0 до 5%",
                "от 5% до 15%",
                "от 15% до 30%",
                "от 30% до 70%",
                "от 70% до 100%"
              };
                  CurrentFilterType = FilterTypes.First();
              });

            MakeAppointmentCommand = new RelayCommand(MakeAppointment);
        }

        private void MakeAppointment(object obj)
        {
            Service service = obj as Service;
            DependencyService.Get<INavigationService>().Navigate<MakeAppointmentViewModel>(service);
        }

        public IEnumerable<Service> Services
        {
            get => _services;

            set
            {
                _services = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> SortTypes
        {
            get => _sortTypes; set
            {
                _sortTypes = value;
                OnPropertyChanged();
            }
        }

        public string CurrentSortType
        {
            get => _currentSortType; set
            {
                _currentSortType = value;
                UpdateServicesAccordingToFilters();
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> FilterTypes
        {
            get => _filterTypes; set
            {
                _filterTypes = value;
                OnPropertyChanged();
            }
        }
        public string CurrentFilterType
        {
            get => _currentFilterType; set
            {
                _currentFilterType = value;
                UpdateServicesAccordingToFilters();
                OnPropertyChanged();
            }
        }

        private async void UpdateServicesAccordingToFilters()
        {
            Services = await ServiceStore.ReadAllAsync();
            SearchServices();
            FilterServices();
            SortServices();
            IEnumerable<Service> allServices = await ServiceStore.ReadAllAsync();
            TotalServicesCount = allServices.Count();
        }

        private void SortServices()
        {
            Services = CurrentSortType == "По стоимости по возрастанию"
                ? Services.OrderBy
                    (
                        s => (double)s.Cost
                             * (s.Discount == 0
                             ? 1
                             : (1 - s.Discount))
                    )
                : CurrentSortType == "По стоимости по убыванию"
                    ? Services.OrderByDescending
                                    (
                                        s => (double)s.Cost * (s.Discount
                                                               == 0
                                                               ? 1
                                                               : (1 - s.Discount))
                                    )
                    : Services;
        }

        private void FilterServices()
        {
            if (CurrentFilterType != null && CurrentFilterType != "Все")
            {
                string[] currentFilterArray = CurrentFilterType.Split(' ');
                double minimumDiscount = Convert.ToInt32
                    (
                        currentFilterArray[1].Replace("%", "")
                    ) * percentToCoefficientFactor;
                double maximumDiscount = Convert.ToInt32
                    (
                        currentFilterArray[3].Replace("%", "")
                    ) * percentToCoefficientFactor;
                Services = Services.Where
                    (
                        s => s.Discount >= minimumDiscount
                             && s.Discount < maximumDiscount
                    );
            }
        }

        private RelayCommand clearCurrentFilterTypeCommand;

        public ICommand ClearCurrentFilterTypeCommand
        {
            get
            {
                if (clearCurrentFilterTypeCommand == null)
                {
                    clearCurrentFilterTypeCommand = new RelayCommand(ClearCurrentFilterType);
                }

                return clearCurrentFilterTypeCommand;
            }
        }

        public string TitleSearchText
        {
            get => _titleSearchText; set
            {
                _titleSearchText = value;
                UpdateServicesAccordingToFilters();
                OnPropertyChanged();
            }
        }

        private void SearchServices()
        {
            if (TitleSearchText != string.Empty)
            {
                Services = Services.Where(s => s.Title.ToLower().Contains(TitleSearchText.ToLower()));
            }
            if (DescriptionSearchText != string.Empty)
            {
                Services = Services.Where(s => s.Description.ToLower().Contains(DescriptionSearchText.ToLower()));
            }
        }

        public string DescriptionSearchText
        {
            get => _descriptionSearchText; set
            {
                _descriptionSearchText = value;
                UpdateServicesAccordingToFilters();
                OnPropertyChanged();
            }
        }

        private void ClearCurrentFilterType(object commandParameter)
        {
            CurrentFilterType = FilterTypes.First();
        }


        private int _totalServicesCount = 0;

        public int TotalServicesCount
        {
            get => _totalServicesCount; set
            {
                _totalServicesCount = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteServiceCommand
        {
            get
            {
                if (_deleteServiceCommand == null)
                {
                    _deleteServiceCommand = new RelayCommand(DeleteService);
                }
                return _deleteServiceCommand;
            }
        }

        private void DeleteService(object obj)
        {
            Service service = obj as Service;
            if (service.ClientService.Count > 0)
            {
                DependencyService.Get<IPopupService>().ShowWarning("Есть информация " +
                    "о записях на услуги (прошлые или будущие), " +
                    "удаление услуги из базы данных запрещено");
                return;
            }
            else
            {
                ServiceStore.Delete(service);
                UpdateServicesAccordingToFilters();
            }
        }

        private RelayCommand addServiceCommand;

        public ICommand AddServiceCommand
        {
            get
            {
                if (addServiceCommand == null)
                {
                    addServiceCommand = new RelayCommand(AddService);
                }

                return addServiceCommand;
            }
        }

        private void AddService(object commandParameter)
        {
            DependencyService.Get<NavigationService>().Navigate<AddEditServiceViewModel>(new Service());
        }

        private RelayCommand goToNearestAppointmentsCommand;

        public ICommand GoToNearestAppointmentsCommand
        {
            get
            {
                if (goToNearestAppointmentsCommand == null)
                {
                    goToNearestAppointmentsCommand = new RelayCommand(GoToNearestAppointments);
                }

                return goToNearestAppointmentsCommand;
            }
        }

        private void GoToNearestAppointments(object commandParameter)
        {
            DependencyService.Get<INavigationService>().Navigate<NearestServicesViewModel>();
        }
    }
}
