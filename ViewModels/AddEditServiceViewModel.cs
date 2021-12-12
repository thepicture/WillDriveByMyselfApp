using WillDriveByMyselfApp.Entities;

namespace WillDriveByMyselfApp.ViewModels
{
    public class AddEditServiceViewModel : ViewModelBase
    {
        private Service _service;

        public AddEditServiceViewModel(Service service)
        {
            Title = service.ID == 0
                ? "Добавление услуги"
                : "Редактирование услуги " + service.Title;
            Service = service;
        }

        public Service Service
        {
            get => _service; set
            {
                _service = value;
                OnPropertyChanged();
            }
        }
    }
}
