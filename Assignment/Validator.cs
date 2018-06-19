using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public static class Validator
    {
        public static bool IsValid(string fromCurrency, string toCurrency)
        {
            // currency must have three character
            var result = true;
            if (fromCurrency.Length != 3 || toCurrency.Length != 3)
            {
                return result = false;
            }
            // currency must be in the list currency which take from website
            Dictionary<string, string> currencylist = ExchangeRateService.FetchCurrency();
            if (!currencylist.Keys.Contains(fromCurrency.ToUpper()) || !currencylist.Keys.Contains(toCurrency.ToUpper()))
            {
                return result = false;
            }


            return result;
        }

       
    }
}
