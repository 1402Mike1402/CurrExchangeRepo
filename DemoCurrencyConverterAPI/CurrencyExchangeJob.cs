using DemoCurrencyConverterAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DemoCurrencyConverterAPI
{
    public class CurrencyExchangeJob : IJob
    {
        private testcurdbEntities dbContext = new testcurdbEntities();
        public void Execute(IJobExecutionContext context)
        {
            string[] currency = { "USD", "GBP", "AUD", "EUR", "CAD", "SGD" };
            try
            {
                foreach (var curr in currency)
                {
                    var client = new RestClient("http://api.fixer.io");
                    var request = new RestRequest("latest?base=" + curr + "&symbols=INR", Method.GET);
                    IRestResponse<CurrencyExchange> response = client.Execute<CurrencyExchange>(request); //client.Execute(request);
                    Exchange objExchange = new Exchange();
                    objExchange.ConversionRate = response.Data.rates.INR;
                    objExchange.SourceCurrency = curr;
                    objExchange.TimeStamp = Convert.ToDateTime(response.Data.date).Ticks;
                    objExchange.ConvertedToCurrency = "INR";
                    objExchange.CreatedDate = DateTime.Now;
                    dbContext.Exchange.Add(objExchange);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}   