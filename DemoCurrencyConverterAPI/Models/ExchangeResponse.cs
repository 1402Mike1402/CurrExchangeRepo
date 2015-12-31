using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoCurrencyConverterAPI.Models
{
    public class ExchangeResponse
    {
        public string SourceCurrency { get; set; }
        public double ConversionRate { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public long TimeStamp { get; set; }
        public string ReturnCode { get; set; }
        public string Error { get; set; }
    }
}