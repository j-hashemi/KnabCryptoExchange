using Exchange.Data.Contexts;
using Exchange.Domain.Entity;
using Exchange.Domain.Repository;

namespace Exchange.Repository
{
    public class CurrencyRepository:BaseRepository<Currency>,ICurrencyRepository
    {
        public CurrencyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}