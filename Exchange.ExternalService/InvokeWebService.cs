using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Exchange.ExternalService
{
    public class InvokeWebService
    {
        private NameValueCollection QueryStringCollection { get; }
        private WebHeaderCollection Headers { get; }
        private UriBuilder Url { get; }

        public InvokeWebService(string url)
        {
            QueryStringCollection = HttpUtility.ParseQueryString(string.Empty);
            Headers = new WebHeaderCollection();
            Url = new UriBuilder(url);
        }

        public void AddQueryString(string key, string value)
        {
            QueryStringCollection.Add(key, value);
        }
        public void AddHeader(string key, string value)
        {
            Headers.Add(key, value);
        }
        public async Task<JToken> Invoke()
        {
            Url.Query = QueryStringCollection.ToString() ?? "";

            var client = new WebClient
            {
                Headers = Headers
            };

            try
            {
                var result = await client.DownloadStringTaskAsync(Url.ToString());
                return JToken.Parse(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"Error in calling ({Url}) method", e);
            }


        }

    }
}