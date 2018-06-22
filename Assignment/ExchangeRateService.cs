using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;

namespace Assignment
{
    public static class ExchangeRateService
    {
        
        public static DataPoint[] GetPreviousExchangeData(DateTime begindate,string fromCurrency, string toCurrency)
        {
            var result = new List<DataPoint>();
            using (var client = new WebClient())
            {
                for (int i = 0; i < 12; i++)
                {
                    result.Add(new DataPoint()
                    {
                        X = i,
                        Y = GetExchangeDataOfDay(begindate.AddMonths(i), fromCurrency, toCurrency,client),
                    });
                }
            }

            return result.ToArray();
        }

        public static Dictionary<string, string> FetchCurrency()
        {
            var url = "https://openexchangerates.org/api/currencies.json";
            var result = new Dictionary<string, string>();
            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            }
            return result;
        }

        public static decimal GetExchangeDataOfDay(DateTime dateTime, string fromCurrency, string toCurrency,WebClient client)
        {
            var appId = ConfigurationManager.AppSettings["appId"];
            var date = dateTime.ToString("yyyy-MM-dd");
            var url = $"https://openexchangerates.org/api/historical/{date}.json?app_id={appId}";
            decimal exchangeRate = 0;           
            var json = client.DownloadString(url);
            var resultExchange = JsonConvert.DeserializeObject<ResultExchange>(json);
            var fromExchange = resultExchange.rates[fromCurrency];
            var toExchange = resultExchange.rates[toCurrency];
            exchangeRate = toExchange / fromExchange;
            
            return exchangeRate;
        }
    }
}
