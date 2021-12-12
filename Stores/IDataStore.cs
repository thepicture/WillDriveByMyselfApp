using System.Collections.Generic;

namespace WillDriveByMyselfApp.Stores
{
    public interface IDataStore<T>
    {
        bool IsLastOperationSuccessful { get; set; }
        void Create(T entity);
        T ReadSingle(object id);
        IEnumerable<T> ReadAll();
        void Update(T entity);
        void Delete(T entity);
    }
}
