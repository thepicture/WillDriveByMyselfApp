using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WillDriveByMyselfApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private string title;

        public string Title
        {
            get => title; set
            {
                title = value;
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
