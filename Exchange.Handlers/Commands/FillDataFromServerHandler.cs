using System.Threading;
using System.Threading.Tasks;
using Exchange.Command.Commands;
using Exchange.Domain.Entity;
using Exchange.Domain.Repository;
using Exchange.ExternalService.CoinMarketCap;
using Exchange.Handlers._Core;

namespace Exchange.Handlers.Commands
{
    public class FillDataFromServerHandler : BaseRequestHandler<FillDataFromServerCommand, FillDataFromServerCommandResponse>
    {
        private readonly ICryptoRepository _cryptoRepository;
        private readonly ICoinMarketCapService _coinMarketCapService;

        public FillDataFromServerHandler(ICryptoRepository cryptoRepository, ICoinMarketCapService coinMarketCapService)
        {
            _cryptoRepository = cryptoRepository;
            _coinMarketCapService = coinMarketCapService;
        }

        protected override async Task<FillDataFromServerCommandResponse> Execute(FillDataFromServerCommand request, CancellationToken cancellationToken)
        {
            var result = new FillDataFromServerCommandResponse();


            if ((await _cryptoRepository.GetAll()).Count > 0)
                return result;

            var data = await _coinMarketCapService.GetCryptoList();

            foreach (var cryptoDto in data)
            {
                if (await _cryptoRepository.ExistsSymbol(cryptoDto.Symbol))
                    continue;

                await _cryptoRepository.Create(new CryptoCurrency(cryptoDto.Name,cryptoDto.Symbol,cryptoDto.Id));
                result.TotalRecordAdded++;
            }

            await _cryptoRepository.UnitOfWork.Commit(cancellationToken);

            return result;
        }
    }
}