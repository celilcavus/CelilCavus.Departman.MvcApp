using CelilCavus.Departman.Model.Interface;

namespace CelilCavus.Departman.Model.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;
        void SaveChanges();
    }

   
}
