using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WillDriveByMyselfApp.Entities;

namespace WillDriveByMyselfApp.ViewModels
{
    public class NearestServicesViewModel : ViewModelBase
    {
        private readonly WillDriveByMyselfBaseEntities _context;
        public NearestServicesViewModel()
        {
            _context = new WillDriveByMyselfBaseEntities();
            NearestAppointments = new List<ClientService>();
            Title = " Ближайшие записи на услуги на сегодня и завтра";
            Timer timer = new Timer(UpdateNearestAppointments);
            timer.Change(0, (int)TimeSpan.FromSeconds(30).TotalMilliseconds);
        }

        private void UpdateNearestAppointments(object state)
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            NearestAppointments = _context.ClientService.ToList()
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
