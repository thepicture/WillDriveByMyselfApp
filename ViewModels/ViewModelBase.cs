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
        public IDataStore<Service> ServiceStore = DependencyService.Get<ServiceDataStore>();

        public string Title
        {
            get => _title; set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
