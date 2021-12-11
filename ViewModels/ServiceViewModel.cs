using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WillDriveByMyselfApp.Commands;
using WillDriveByMyselfApp.Entities;

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
        public ServiceViewModel()
        {
            Title = "Список услуг";
            Services = ServiceStore.ReadAll().ToList();
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
        }

        public IEnumerable<Service> Services
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
                UpdateServicesOrder();
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
                UpdateServicesOrder();
                OnPropertyChanged();
            }
        }

        private void UpdateServicesOrder()
        {
            Services = ServiceStore.ReadAll().ToList();
            FilterServices();
            SortServices();
        }

        private void SortServices()
        {
            if (CurrentSortType == "По стоимости по возрастанию")
            {
                Services = Services.OrderBy
                    (
                        s => (double)s.Cost
                             * (s.Discount == 0 ? 1 : (1 - s.Discount))
                    );
            }
            else if (CurrentSortType == "По стоимости по убыванию")
            {
                Services = Services.OrderByDescending
                    (
                        s => (double)s.Cost * (s.Discount
                                               == 0 ? 1 : (1 - s.Discount))
                    );
            }
            else
            {
                ServiceStore.ReadAll().ToList();
            }
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
                Services = ServiceStore.ReadAll().Where
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
                OnSearchTextChanged();
                OnPropertyChanged();
            }
        }

        private void OnSearchTextChanged()
        {
            Services = ServiceStore.ReadAll().ToList();
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
                OnSearchTextChanged();
                OnPropertyChanged();
            }
        }

        private void ClearCurrentFilterType(object commandParameter)
        {
            CurrentFilterType = FilterTypes.First();
        }
    }
}
