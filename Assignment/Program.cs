using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Configuration;


namespace Assignment
{
    class Program
    {
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            try
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
            catch (Exception e)
            {

                log.Info(e.Message);
            }
                        

        }

        private static float CalculatePredictExchange(string fromCurrency, string toCurrency)
        {
            var begindate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);
            if (begindate.Day < 15)
            {
                begindate = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 15);
            }
            var datas = ExchangeRateService.GetPreviousExchangeData(begindate,fromCurrency, toCurrency);
           
            return Calculator.LinearRegression(datas);
        }       

    }
}
