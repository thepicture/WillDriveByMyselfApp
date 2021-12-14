using System.ComponentModel;
using System.Runtime.CompilerServices;
using WillDriveByMyselfApp.Entities;
using WillDriveByMyselfApp.Services;
using WillDriveByMyselfApp.Stores;

namespace WillDriveByMyselfApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private string _title = string.Empty;
        private bool _isBusy;
        public IDataStore<Service> ServiceStore = DependencyService.Get<IDataStore<Service>>();
        public IDataStore<Client> ClientStore = DependencyService.Get<IDataStore<Client>>();

        public string Title
        {
            get => _title; set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
