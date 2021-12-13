using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WillDriveByMyselfApp.Entities;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.Stores
{
    public class ClientAppointmentDataStore : IDataStore<Client>
    {
        private readonly WillDriveByMyselfBaseEntities context;

        public bool IsLastOperationSuccessful { get; set; }

        public ClientAppointmentDataStore()
        {
            context = new WillDriveByMyselfBaseEntities();
        }

        public void MakeAppointment(Client client,
                                    ClientService appointment)
        {
            client.ClientService.Add(appointment);
        }

        public void Create(Client entity)
        {
            throw new NotImplementedException();
        }

        public Client ReadSingle(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> ReadAllAsync()
        {
            return await Task.FromResult(new WillDriveByMyselfBaseEntities().Client.ToList());
        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Client entity)
        {
            throw new NotImplementedException();
        }

        private void SaveChanges()
        {
            try
            {
                _ = context.SaveChanges();
                DependencyService.Get<IPopupService>().ShowInfo("Клиент " +
                    "успешно записан на услугу");
                IsLastOperationSuccessful = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                DependencyService.Get<IPopupService>().ShowError("Не удалось " +
                  "записать клиента " +
                  "на услугу. Попробуйте произвести действия ещё раз");
                IsLastOperationSuccessful = false;
            }
        }
    }
}