using System.Threading.Tasks;
using Exchange.ExternalService.ForeignExchange;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exchange.Test.UnitTests.ExternalServiceTests
{
    [TestClass]
    public class ForeignExchangeRateServiceTest
    {
        [TestMethod]
        public  async  Task InvokeService_Success()
        {
            var service = new ForeignExchangeRate();
            var result =  await service.GetLatestExchangeRates();
            
            Assert.AreNotEqual(result.Count,0);
        }
    }
}