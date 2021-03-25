using System;
using Exchange.Domain.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exchange.Test.UnitTests.Domain
{
    [TestClass]
    public class CurrencyTest
    {
        [TestMethod]
        public void Currency_Ctr_Success()
        {
            string name = "dollar", code = "USD", countryCode = "US";

            var currency = new Currency(code,name,countryCode);

            Assert.AreEqual(code,currency.Code);
            Assert.AreEqual(name,currency.Name);
            Assert.AreEqual(countryCode,currency.CountryCode);
        }
        
        [TestMethod]
        public void Currency_Ctr_Name_Is_Null_Fail()
        {
            string  code = "USD", countryCode = "US";

            Assert.ThrowsException<ArgumentNullException>(()=> new Currency(code, string.Empty, countryCode));
        }
        
        [TestMethod]
        public void Currency_Ctr_Code_Is_Null_Fail()
        {
            string name = "dollar", countryCode = "US";

            Assert.ThrowsException<ArgumentNullException>(()=> new Currency(string.Empty, name, countryCode));
        }

    }
}