using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Exchange.Command.Queries;
using Exchange.Domain.Entity;
using Exchange.Domain.Repository;
using Exchange.Handlers._Core;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Handlers.Queries
{
    public class CryptoCurrencyListQueryHandler : BaseQueryHandler<CryptoCurrencyListQuery, CryptoCurrencyListQueryResponse>
    {
        private readonly ICryptoRepository _cryptoRepository;

        public CryptoCurrencyListQueryHandler(ICryptoRepository cryptoRepository)
        {
            _cryptoRepository = cryptoRepository ?? throw new ArgumentNullException(nameof(cryptoRepository));
        }

        protected override async Task<CryptoCurrencyListQueryResponse> Run(CryptoCurrencyListQuery request, CancellationToken cancellationToken)
        {
            var result = new CryptoCurrencyListQueryResponse();

             var unitOfWork = _cryptoRepository.UnitOfWork;

            var query = _cryptoRepository.GetQueryable();

            result.TotalCount = query.Count();
            
            result.Entities = await query.OrderBy(x => x.CoinMarketCapId).Skip(request.Skip).Take(request.Take)
                .Select(x => MapToResponseItem(x)).ToListAsync(cancellationToken);
            
            await unitOfWork.Commit(cancellationToken);
                   
            return result;
        }

        private static CryptoCurrencyListQueryResultItem MapToResponseItem(CryptoCurrency x)
        {
            return new CryptoCurrencyListQueryResultItem
            {
                Id = x.Id,
                CoinMarketCapId = x.CoinMarketCapId,
                Name = x.Name,
                Symbol = x.Symbol
            };
        }
    }
}