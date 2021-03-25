using System.Threading.Tasks;
using Exchange.Data.Contexts;
using Exchange.Domain.Entity;
using Exchange.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Repository
{
    public class CryptoCurrencyRepository:BaseRepository<CryptoCurrency>,ICryptoRepository
    {
        public CryptoCurrencyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsSymbol(string symbol)
        {
            return await DbSet.AnyAsync(x => x.Symbol == symbol);
        }
    }
}