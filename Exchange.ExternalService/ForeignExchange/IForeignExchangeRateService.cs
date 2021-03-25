using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.ExternalService.ForeignExchange
{
    public interface IForeignExchangeRateService : IExternalService
    {
        Task<Dictionary<string, decimal>> GetLatestExchangeRates();
    }
}