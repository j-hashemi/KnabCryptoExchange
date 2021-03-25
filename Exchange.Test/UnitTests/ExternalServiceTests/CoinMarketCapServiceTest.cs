using System.Linq;
using System.Threading.Tasks;
using Exchange.ExternalService.CoinMarketCap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exchange.Test.UnitTests.ExternalServiceTests
{
    [TestClass]
    public class CoinMarketCapServiceTest
    {
        [TestMethod]
        public async Task GetCryptoRate_Success()
        {
            var service = new CoinMarketCapService();
            var result = await service.GetCryptoRate("BTC");

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.EurQuote, 0);
        }

        [TestMethod]
        public async Task GetCryptoList_Success()
        {
            var service = new CoinMarketCapService();
            var result = await service.GetCryptoList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
    }
}