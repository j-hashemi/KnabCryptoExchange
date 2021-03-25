using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exchange.Domain._Core;
using Exchange.Domain.Entity;

namespace Exchange.Domain.Repository
{
    public interface IRepository<T> where T:BusinessEntity
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> Create(T value);
        T Update(T value);
        void Delete(T value);
        Task<T> GetById(int id);
        Task<List<T>>  GetAll();
        IQueryable<T> GetQueryable();
    }
}