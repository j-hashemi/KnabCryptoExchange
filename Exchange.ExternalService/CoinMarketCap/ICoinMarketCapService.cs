using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exchange.Command.DTO;
using Newtonsoft.Json.Linq;

namespace Exchange.ExternalService.CoinMarketCap
{
    public interface ICoinMarketCapService : IExternalService
    {
        Task<CryptoDto> GetCryptoRate(string symbol
        );
        Task<List<CryptoDto>> GetCryptoList();
    }

    public class CoinMarketCapService : ICoinMarketCapService
    {
        private static string API_KEY = "254e5c97-f8b1-44c6-b16c-5d2b4f2ca666";
        private static string BASE_URL = "https://pro-api.coinmarketcap.com/v1/cryptocurrency";
        public async Task<CryptoDto> GetCryptoRate(string symbol)
        {
            var service = new InvokeWebService($"{BASE_URL}/quotes/latest");

            service.AddQueryString("symbol", symbol);
            service.AddQueryString("convert", "EUR");
            
            service.AddHeader("X-CMC_PRO_API_KEY", API_KEY);
            service.AddHeader("Accepts", "application/json");

            var result = await service.Invoke();
            var cryptoInformation = result?["data"]?[symbol];

            return ConvertToCrypto(cryptoInformation);
        }

        public async Task<List<CryptoDto>> GetCryptoList()
        {
            var service = new InvokeWebService($"{BASE_URL}/map");
            service.AddQueryString("sort", "cmc_rank");
            service.AddQueryString("limit", "110");

            service.AddHeader("X-CMC_PRO_API_KEY", API_KEY);
            service.AddHeader("Accepts", "application/json");
            
            var result = await service.Invoke();
            var data = result["data"];
            
            return data?.Select(ConvertToCrypto).ToList();
        }



        private CryptoDto ConvertToCrypto(JToken cryptoInformation)
        {
            if (cryptoInformation?["symbol"] == null) return null;

            var result = new CryptoDto
            {
                Symbol = cryptoInformation["symbol"]?.ToString(),
                Name = cryptoInformation["name"]?.ToString(),
                Id = Convert.ToInt16(cryptoInformation["id"])
            };

            if (cryptoInformation["quote"]?["EUR"]?["price"] != null)
                result.EurQuote = Convert.ToDecimal(cryptoInformation["quote"]["EUR"]["price"].ToString());
            
            return result;
        }


    }
}