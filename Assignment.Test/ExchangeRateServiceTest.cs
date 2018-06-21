using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Test
{
    [TestClass]
    public class ExchangeRateServiceTest
    {
        [TestMethod]
        public void TestFetchCurrency()
        {
            var result = ExchangeRateService.FetchCurrency();
            Assert.IsTrue(result.ContainsKey("USD"));
        }
        [TestMethod]
        public void TestGetExchangeDataOfDay()
        {
            var date = new DateTime(2018, 1, 1);
            var fromCurrency = "USD";
            var toCurrency = "VND";
            var result = ExchangeRateService.GetExchangeDataOfDay(date,fromCurrency,toCurrency);
            Assert.AreEqual(result, 22700.883864);
        }
        [TestMethod]
        public void TestGetPreviousExchangeData()
        {
            var date = new DateTime(2018, 1, 1);
            var fromCurrency = "USD";
            var toCurrency = "VND";
            var result = ExchangeRateService.GetPreviousExchangeData(date,fromCurrency, toCurrency);
            Assert.AreEqual(result.Length, 12);
        }
    }
}
