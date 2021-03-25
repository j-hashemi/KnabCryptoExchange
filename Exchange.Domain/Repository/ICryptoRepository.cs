using System.Threading.Tasks;
using Exchange.Domain.Entity;

namespace Exchange.Domain.Repository
{
    public interface ICryptoRepository  :IRepository<CryptoCurrency>
    {
        Task<bool> ExistsSymbol(string symbol);
    }
}