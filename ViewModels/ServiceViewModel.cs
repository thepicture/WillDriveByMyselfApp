using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WillDriveByMyselfApp.Entities;

namespace WillDriveByMyselfApp.ViewModels
{
    public class ServiceViewModel : ViewModelBase
    {
        private ObservableCollection<Service> _services;
        private IEnumerable<string> _sortTypes;
        private string _currentSortType;
        public ServiceViewModel()
        {
            Title = "Список услуг";
            Services = new ObservableCollection<Service>(ServiceStore.ReadAll());
            SortTypes = new List<string>
            {
                "Без сортировки",
                "По стоимости по возрастанию",
                "По стоимости по убыванию",
            };
            CurrentSortType = SortTypes.First();
        }

        public ObservableCollection<Service> Services
        {
            get => _services; set
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
                OnSortTypeChanged();
                OnPropertyChanged();
            }
        }

        private void OnSortTypeChanged()
        {
            if (CurrentSortType == "По стоимости по возрастанию")
            {
                Services = new ObservableCollection<Service>(Services.OrderBy(s => (double)s.Cost * (s.Discount == 0 ? 1 : (1 - s.Discount))));
            }
            else if (CurrentSortType == "По стоимости по убыванию")
            {
                Services = new ObservableCollection<Service>(Services.OrderByDescending(s => (double)s.Cost * (s.Discount == 0 ? 1 : (1 - s.Discount))));
            }
            else
            {
                Services = new ObservableCollection<Service>(ServiceStore.ReadAll());
            }
        }
    }
}
