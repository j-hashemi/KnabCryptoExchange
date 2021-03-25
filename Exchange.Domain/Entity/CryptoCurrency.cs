using System;
using System.ComponentModel.DataAnnotations;



namespace Exchange.Domain.Entity
{
    public class CryptoCurrency : BusinessEntity
    {
        protected CryptoCurrency()
        {

        }

        public CryptoCurrency(string name, string symbol, int coinMarketCapId)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Symbol = string.IsNullOrEmpty(symbol) ? throw new ArgumentNullException(nameof(symbol)) : symbol;
            CoinMarketCapId = CheckCoinMarketIdValidation(coinMarketCapId);
        }



        [Required]
        public string Name { get; set; }
        [Required]
        public string Symbol { get; set; }
        public int CoinMarketCapId { get; set; }

        private static int CheckCoinMarketIdValidation(int coinMarketCapId)
        {
            return coinMarketCapId > 0
                ? coinMarketCapId
                : throw new ArgumentOutOfRangeException(nameof(coinMarketCapId));
        }
    }
}
