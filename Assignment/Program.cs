using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Configuration;


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

            if (Validator.IsValid(fromCurrency, toCurrency))
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
            var datas = ExchangeRateService.GetPreviousExchangeData(fromCurrency, toCurrency);
           
            return Calculator.LinearRegression(datas);
        }       

    }
}
