using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WillDriveByMyselfApp.Entities;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.Stores
{
    public class ServiceDataStore : IDataStore<Service>
    {
        private readonly WillDriveByMyselfBaseEntities context;

        public bool IsLastOperationSuccessful { get; set; }

        public ServiceDataStore()
        {
            context = new WillDriveByMyselfBaseEntities();
        }

        public void Create(Service entity)
        {
            _ = context.Service.Add(entity);
            SaveChanges();
        }

        public Service ReadSingle(object id)
        {
            return context.Service.Find(id);
        }

        public async Task<IEnumerable<Service>> ReadAllAsync()
        {
            return await Task.FromResult(new WillDriveByMyselfBaseEntities().Service.ToList());
        }

        public void Update(Service entity)
        {
            context.Entry(entity).CurrentValues.SetValues(entity);
            SaveChanges();
        }

        public void Delete(Service entity)
        {
            _ = context.Service.Remove(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                _ = context.SaveChanges();
                DependencyService.Get<IPopupService>().ShowInfo("Услуга " +
                    "успешно обновлена в базе данных");
                IsLastOperationSuccessful = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                DependencyService.Get<IPopupService>().ShowError("Не удалось " +
                  "изменить услугу. Попробуйте произвести действия ещё раз");
                IsLastOperationSuccessful = false;
            }
        }
    }
}
