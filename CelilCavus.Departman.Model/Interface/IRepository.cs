using System.Collections.Generic;

namespace CelilCavus.Departman.Model.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Remove(T item);
        IEnumerable<T> GetList();
        T GetById(int? id);
    }
}
