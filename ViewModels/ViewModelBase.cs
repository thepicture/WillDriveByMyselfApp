using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WillDriveByMyselfApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private string _title;

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
