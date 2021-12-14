using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WillDriveByMyselfApp.Entities;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.ViewModels
{
    public class NearestServicesViewModel : ViewModelBase
    {
        public NearestServicesViewModel()
        {
            NearestAppointments = new List<ClientService>();
            Title = " Ближайшие записи на услуги на сегодня и завтра";
            Timer timer = new Timer(UpdateNearestAppointments);
            if (!timer.Change(0, (int)TimeSpan.FromSeconds(30).TotalMilliseconds))
            {
                DependencyService.Get<IPopupService>().ShowError("Не удалось " +
                    "настроить автообновление данных. Перезайдите на страницу");
            }
        }

        private void UpdateNearestAppointments(object state)
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            NearestAppointments = ClientServiceStore.ReadAllAsync()
                .Result
                .Where(s => DateTime.Now
                .Subtract(s.StartTime) < TimeSpan.FromDays(2));
            IsBusy = false;
        }

        private IEnumerable<ClientService> _nearestAppointments;

        public IEnumerable<ClientService> NearestAppointments
        {
            get => _nearestAppointments;
            set => SetProperty(ref _nearestAppointments, value);
        }
    }
}
