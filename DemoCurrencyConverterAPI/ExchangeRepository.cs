using DemoCurrencyConverterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoCurrencyConverterAPI
{
    public class ExchangeRepository
    {
        private static testcurdbEntities dbContext = new testcurdbEntities();
       
        public Exchange GetExchangeRate(ExchangeRequest request)
        {            
            try {
                var query = (from exchange in dbContext.Exchange
                             where exchange.SourceCurrency == request.CurrencyCode
                             orderby exchange.CreatedDate descending                             
                             select exchange).FirstOrDefault();
                return query;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
       
    }
}