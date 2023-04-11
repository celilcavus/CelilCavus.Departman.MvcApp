using CelilCavus.Departman.Context.Contexts;
using CelilCavus.Departman.Model.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CelilCavus.Departman.Model.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContextDb _context;
        private readonly DbSet<T> _set;

        public BaseRepository(ApplicationContextDb context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public void Add(T item)
        {
            _set.Add(item);
        }

        public T GetById(int? id)
        {
            return _set.Find(id);
        }

        public IEnumerable<T> GetList()
        {
            var values = _set.ToList();
            return values;
        }

        public void Remove(T item)
        {
            _set.Remove(item);
        }

        public void Update(T item)
        {

        }
    }
}
