using System;
using Exchange.Domain.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exchange.Test.UnitTests.Domain
{
    [TestClass]
    public class CryptoCurrencyTest
    {
        [TestMethod]
        public void CryptoCurrency_Ctr_Success()
        {
            string name = "Bitcoin", symbol = "BTC";
            int coinMarketId = 1;

            var btc = new CryptoCurrency(name,symbol,coinMarketId);
            
            Assert.AreEqual(btc.CoinMarketCapId,coinMarketId);
            Assert.AreEqual(btc.Name,name);
            Assert.AreEqual(btc.Symbol,symbol);
        }
        
        [TestMethod]
        public void CryptoCurrency_Ctr_Name_Is_Null_Fail()
        {
            string  symbol = "BTC";
            int coinMarketId = 1;

            Assert.ThrowsException<ArgumentNullException>(() => new CryptoCurrency(String.Empty, symbol, coinMarketId));
        }
        
        [TestMethod]
        public void CryptoCurrency_Ctr_Symbol_Is_Null_Fail()
        {
            string name = "Bitcoin";
            int coinMarketId = 1;

            Assert.ThrowsException<ArgumentNullException>(() => new CryptoCurrency(name, string.Empty, coinMarketId));
        }
        
        [TestMethod]
        public void CryptoCurrency_Ctr_CoinMarketId_Is_OutOfRange_Fail()
        {
            string name = "Bitcoin", symbol = "BTC";
            int coinMarketId = 0;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new CryptoCurrency(name, symbol, coinMarketId));
        }
    }
}