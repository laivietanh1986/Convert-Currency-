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
                    decimal predictExchange = CalculatePredictExchange(fromCurrency.ToUpper(), toCurrency.ToUpper());
                    Console.WriteLine($"The predicted currency exchange from {fromCurrency} to {toCurrency}for 15/1/2017 is {(predictExchange.ToString("")).ToString()}");
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

        private static decimal CalculatePredictExchange(string fromCurrency, string toCurrency)
        {
            var begindate = new DateTime(DateTime.Today.AddMonths(-11).Year, DateTime.Today.AddMonths(-11).Month, 15);

            if (DateTime.Today.Day < 15)
            {
                begindate = new DateTime(DateTime.Today.AddMonths(-12).Year, DateTime.Today.AddMonths(-12).Month, 15);
            }
          
            var datas = ExchangeRateService.GetPreviousExchangeData(begindate,fromCurrency, toCurrency);
           
            var calc =   Calculator.LinearRegression(datas);
            decimal a = calc.X; //  intercept
            decimal b = calc.Y; //  slope
            return a + b * 13;
        }       

    }
}
