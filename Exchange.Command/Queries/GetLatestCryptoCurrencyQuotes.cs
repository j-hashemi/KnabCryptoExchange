using System.Collections.Generic;
using Exchange.Command.Core;

namespace Exchange.Command.Queries
{
    public class GetLatestCryptoCurrencyQuotes:BaseQuery<GetLatestCryptoCurrencyQuotesResponse>
    {
        public int Id { get; set; }

        public GetLatestCryptoCurrencyQuotes(int id)
        {
            Id = id;
        }
    }

    public class GetLatestCryptoCurrencyQuotesResponse : BaseSingleQueryResponse<GetLatestCryptoCurrencyQuotesItem>
    {
        
    }

    public class GetLatestCryptoCurrencyQuotesItem
    {
        public int Id { get; set; }
        public List<QuoteDto> Quotes { get; set; }
    }

    public class QuoteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CountryCode { get; set; }
        public decimal Value { get; set; }
    }
}