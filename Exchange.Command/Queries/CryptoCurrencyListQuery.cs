using Exchange.Command.Core;

namespace Exchange.Command.Queries
{
    public class CryptoCurrencyListQuery : BaseQuery<CryptoCurrencyListQueryResponse>
    {
        
    }

    public class CryptoCurrencyListQueryResponse : BaseQueryResponse<CryptoCurrencyListQueryResultItem>
    {
    }


    public class CryptoCurrencyListQueryResultItem 
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int CoinMarketCapId { get; set; }
    }
}