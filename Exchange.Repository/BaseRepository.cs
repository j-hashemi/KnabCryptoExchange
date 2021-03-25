using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exchange.Data.Contexts;
using Exchange.Domain._Core;
using Exchange.Domain.Entity;
using Exchange.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BusinessEntity
    {

        protected ApplicationDbContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }
        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IUnitOfWork UnitOfWork => Context;

        public async Task<T> Create(T value)
        {
            var result = await DbSet.AddAsync(value);
            return result.Entity;
        }

        public T Update(T value)
        {
            var result =DbSet.Update(value);
            return result.Entity;
        }

        public void Delete(T value)
        {
            DbSet.Remove(value);
        }

        public async Task<T> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return DbSet.AsQueryable();
        }
    }
}
