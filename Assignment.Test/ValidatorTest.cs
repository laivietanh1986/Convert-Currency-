using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Test
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void CurrencyMustHaveThreeCharacter()
        {
            var fromCurrency = "vnd";
            var toCurrency = "usd";
            var resultValid = Validator.IsValid(fromCurrency, toCurrency);
            Assert.IsTrue(resultValid);
        }
        [TestMethod]
        public void CurrencyMustNotHaveMoreOrLessThreeCharacter()
        {
            var fromCurrency = "vnda";
            var toCurrency = "uad";
            var resultValid = Validator.IsValid(fromCurrency, toCurrency);
            Assert.IsFalse(resultValid);
        }
        [TestMethod]
        public void CurrencyNotInCurrencyList()
        {
            var fromCurrency = "vad";
            var toCurrency = "uad";
            var resultValid = Validator.IsValid(fromCurrency, toCurrency);
            Assert.IsFalse(resultValid);
        }
        [TestMethod]
        public void CurrencyInCurrencyList()
        {
            var fromCurrency = "vnd";
            var toCurrency = "usd";
            var resultValid = Validator.IsValid(fromCurrency, toCurrency);
            Assert.IsTrue(resultValid);
        }
    }
}
