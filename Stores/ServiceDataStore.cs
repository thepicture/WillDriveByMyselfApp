using System;
using System.Collections.Generic;
using System.Diagnostics;
using WillDriveByMyselfApp.Entities;
using WillDriveByMyselfApp.Services;

namespace WillDriveByMyselfApp.Stores
{
    public class ServiceDataStore : IDataStore<Service>
    {
        private readonly WillDriveByMyselfBaseEntities context;

        public ServiceDataStore()
        {
            context = new WillDriveByMyselfBaseEntities();
        }

        public void Create(Service entity)
        {
            context.Service.Add(entity);
            SaveChanges();
        }

        public Service ReadSingle(object id)
        {
            return context.Service.Find(id);
        }

        public IEnumerable<Service> ReadAll()
        {
            return context.Service;
        }

        public void Update(Service entity)
        {
            context.Entry(entity).CurrentValues.SetValues(entity);
            SaveChanges();
        }

        public void Delete(Service entity)
        {
            context.Service.Remove(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                context.SaveChanges();
                DependencyService.Get<MessageBoxPopupService>().ShowInfo("Услуга " +
                    "успешно обновлена в базе данных");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                DependencyService.Get<MessageBoxPopupService>().ShowError("Не удалось " +
                  "изменить услугу. Попробуйте произвести действия ещё раз");
            }
        }
    }
}
