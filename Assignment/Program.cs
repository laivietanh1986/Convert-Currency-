using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please input from Currency:");
            var fromCurrency = Console.ReadLine();

            Console.WriteLine("Please input to Currency:");
            var toCurrency = Console.ReadLine();

            if (isValid(fromCurrency, toCurrency))
            {
                float predictExchange = CalculatePredictExchange(fromCurrency.ToUpper(), toCurrency.ToUpper());
                Console.WriteLine($"The predicted currency exchange from {fromCurrency} to {toCurrency}for 15/1/2017 is {predictExchange}");
            }
            else
            {
                Console.WriteLine(
                    $"Input is invalid.\n" +
                    $"Currency must have three character \n" +
                    $"currency must be in the list currency which take from website \n");
            }

        }

        private static float CalculatePredictExchange(string fromCurrency, string toCurrency)
        {
            var datas = GetPreviousExchangeData(fromCurrency, toCurrency);
            return 0;
        }

        private static List<float> GetPreviousExchangeData(string fromCurrency, string toCurrency)
        {
            var result = new List<float>();
            var begindate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);

            if (DateTime.Today.Day < 15)
            {
                begindate = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 15);
            }
            for (int i = 0; i < 12; i++)
            {
                result.Add(GetExchangeDataOfDay(begindate.AddMonths(-i), fromCurrency, toCurrency));
            }
            
            return result;
        }

        private static float GetExchangeDataOfDay(DateTime dateTime, string fromCurrency, string toCurrency)
        {
            var appId = "3ba8155bd1334768a53574490b3caf1d";
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

        

        private static bool isValid(string fromCurrency, string toCurrency)
        {
            // currency must have three character
            var result = true;
            if (fromCurrency.Length != 3 || toCurrency.Length != 3)
            {
                return result = false;
            }
            // currency must be in the list currency which take from website
            Dictionary<string, string> currencylist = FetchCurrency();
            if (!currencylist.Keys.Contains(fromCurrency.ToUpper()) || !currencylist.Keys.Contains(toCurrency.ToUpper()))
            {
                return result = false;
            }


            return result;
        }

        private static Dictionary<string, string> FetchCurrency()
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

        public class ResultExchange
        {
            public string disclaimer { get; set; }
            public string license { get; set; }
            public int timestamp { get; set; }
            public string _base { get; set; }
            public Dictionary<string,float> rates { get; set; }
        }

        
        

    }
}
