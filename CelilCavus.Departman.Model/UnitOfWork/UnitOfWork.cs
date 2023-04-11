using CelilCavus.Departman.Context.Contexts;
using CelilCavus.Departman.Model.Interface;
using CelilCavus.Departman.Model.Repository;
using System.Data.Entity;

namespace CelilCavus.Departman.Model.UnitOfWork
{
    public class UnitOfDWork : IUnitOfWork
    {
        private readonly ApplicationContextDb _context;

        public UnitOfDWork(ApplicationContextDb context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new BaseRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
