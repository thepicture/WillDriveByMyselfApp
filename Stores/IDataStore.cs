using System.Collections.Generic;
using System.Threading.Tasks;

namespace WillDriveByMyselfApp.Stores
{
    public interface IDataStore<T>
    {
        bool IsLastOperationSuccessful { get; set; }
        void Create(T entity);
        T ReadSingle(object id);
        Task<IEnumerable<T>> ReadAllAsync();
        void Update(T entity);
        void Delete(T entity);
    }
}
