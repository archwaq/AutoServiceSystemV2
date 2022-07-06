using System.Collections.Generic;

namespace AutoServiceSystem.DataAccessLayer
{
    public interface IRepository<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(int? id);
        T Read(int? id);
        List<T> ReadAll();
    }
}
