using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public static class ExchangeRateService
    {
        public static DataPoint[] GetPreviousExchangeData(string fromCurrency, string toCurrency)
        {
            var result = new List<DataPoint>();
            var begindate = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(12).Month, 15);

            if (DateTime.Today.Day < 15)
            {
                begindate = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(13).Month, 15);
            }
            for (int i = 0; i < 12; i++)
            {
                result.Add(new DataPoint()
                {
                    X = GetExchangeDataOfDay(begindate.AddMonths(i), fromCurrency, toCurrency),
                    Y = i
                });
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

        public static float GetExchangeDataOfDay(DateTime dateTime, string fromCurrency, string toCurrency)
        {
            var appId = ConfigurationManager.AppSettings["appId"];
            var date = dateTime.ToString("yyyy-MM-dd");
            var url = $"https://openexchangerates.org/api/historical/{date}.json?app_id={appId}";
            float exchangeRate = 0;
            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                var resultExchange = JsonConvert.DeserializeObject<ResultExchange>(json);
                var fromExchange = resultExchange.rates[fromCurrency];
                var toExchange = resultExchange.rates[toCurrency];
                exchangeRate = toExchange / fromExchange;
            }
            return exchangeRate;
        }
    }
}
