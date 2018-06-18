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
            var fromCurrency= Console.ReadLine();

            Console.WriteLine("Please input to Currency:");
            var toCurrency = Console.ReadLine();

            if (isValid(fromCurrency,toCurrency))
            {
                Console.WriteLine($"The predicted currency exchange from {fromCurrency} to {toCurrency}for 15/1/2017 is");
            }
            else
            {
                Console.WriteLine(
                    $"Input is invalid.\n" +
                    $"Currency must have three character \n"+
                    $"currency must be in the list currency which take from website \n");
            }

        }

        private static bool isValid(string fromCurrency, string toCurrency)
        {
            // currency must have three character
            var result = true;
            if (fromCurrency.Length == 3 || toCurrency.Length == 3)
            {
               return  result = false;
            }
            // currency must be in the list currency which take from website
            Dictionary<string,string> currencylist = FetchCurrency();
            if (!currencylist.Keys.Contains(fromCurrency) || !currencylist.Keys.Contains(toCurrency))
            {
                return result = false;
            }


            return result;
        }

        private static Dictionary<string,string> FetchCurrency()
        {
            var url = "https://openexchangerates.org/api/currencies.json";
            var result = new Dictionary<string, string>();
            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
              
            }
            return result;
        }
    }
}
