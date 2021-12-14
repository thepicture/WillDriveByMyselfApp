using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillDriveByMyselfApp.Entities;

namespace WillDriveByMyselfApp.Stores
{
    public class ClientServiceDataStore : IDataStore<ClientService>
    {
        private readonly WillDriveByMyselfBaseEntities _context;

        public ClientServiceDataStore()
        {
            _context = new WillDriveByMyselfBaseEntities();
        }

        public bool IsLastOperationSuccessful
        {
            get;
            set;
        }

        public void Create(ClientService entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClientService entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClientService>> ReadAllAsync()
        {
            return await Task.FromResult(_context.ClientService.ToList());
        }

        public ClientService ReadSingle(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientService entity)
        {
            throw new NotImplementedException();
        }
    }
}
