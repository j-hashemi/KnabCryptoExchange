using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Exchange.ExternalService.ForeignExchange
{
    public class ForeignExchangeRate: IForeignExchangeRateService
    {
        public async Task<Dictionary<string, decimal>> GetLatestExchangeRates()
        {
            var dic = new Dictionary<string, decimal>();

            var service = new InvokeWebService("https://api.exchangeratesapi.io/latest");
            var result = await service.Invoke();
            
            var rates = result["rates"];
            if (rates == null) return dic;
            
            foreach (var jToken in rates)
            {
                var item = (JProperty) jToken;
                dic.Add(item.Name, Convert.ToDecimal(item.Value.ToString()));
            }
            dic.Add("EUR",1);
            return dic;
        } 
    }
}