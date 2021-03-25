using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Exchange.Command.Queries;
using Exchange.Domain.Entity;
using Exchange.Domain.Repository;
using Exchange.ExternalService.CoinMarketCap;
using Exchange.ExternalService.ForeignExchange;
using Exchange.Handlers._Core;

namespace Exchange.Handlers.Queries
{
    public class GetLatestCryptoCurrencyQuotesHandler : BaseQueryHandler<GetLatestCryptoCurrencyQuotes, GetLatestCryptoCurrencyQuotesResponse>
    {
        private readonly ICryptoRepository _cryptoRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICoinMarketCapService _coinMarketCapService;
        private readonly IForeignExchangeRateService _exchangeRateService;

        public GetLatestCryptoCurrencyQuotesHandler(ICryptoRepository cryptoRepository,
            ICurrencyRepository currencyRepository, ICoinMarketCapService coinMarketCapService,
            IForeignExchangeRateService exchangeRateService)
        {
            _cryptoRepository = cryptoRepository ?? throw new ArgumentNullException(nameof(cryptoRepository));
            _currencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
            _coinMarketCapService =
                coinMarketCapService ?? throw new ArgumentNullException(nameof(coinMarketCapService));
            _exchangeRateService = exchangeRateService ?? throw new ArgumentNullException(nameof(exchangeRateService));
        }

        protected override async Task<GetLatestCryptoCurrencyQuotesResponse> Run(GetLatestCryptoCurrencyQuotes request,
            CancellationToken cancellationToken)
        {
            var result = new GetLatestCryptoCurrencyQuotesResponse();
            var cryptoCurrency = await _cryptoRepository.GetById(request.Id);
            if (cryptoCurrency == null)
                throw new Exception("Crypto Currency was not found");

            result.Entity = new GetLatestCryptoCurrencyQuotesItem
            {
                Id = cryptoCurrency.Id
            };

            var latestQuote = await GetLatestCryptoCurrencyQuote(cryptoCurrency);
            var currencies = await _currencyRepository.GetAll();
            var rates = await _exchangeRateService.GetLatestExchangeRates();

            result.Entity.Quotes = currencies.Select(ConvertCurrencyToDto(rates, latestQuote)).ToList();

            return result;
        }

        private Func<Currency, QuoteDto> ConvertCurrencyToDto(Dictionary<string, decimal> rates, decimal latestQuote)
        {
            return quote =>
                new QuoteDto
                {
                    Code = quote.Code,
                    CountryCode = quote.CountryCode,
                    Name = quote.Name,
                    Value = GetCryptoRate(rates[quote.Code], latestQuote)
                };
        }

        private async Task<decimal> GetLatestCryptoCurrencyQuote(CryptoCurrency cryptoCurrency)
        {
            var data = await _coinMarketCapService.GetCryptoRate(cryptoCurrency.Symbol);
            if (data.EurQuote <= 0) throw new Exception("Error in calling service for getting latest crypto quote");

            return data.EurQuote;
        }

        private decimal GetCryptoRate(Money ratePerBaseCurrency, Money cryptoRate)
        {
            var rate = cryptoRate * ratePerBaseCurrency;
            return Math.Round(rate, 2);
        }
    }
}