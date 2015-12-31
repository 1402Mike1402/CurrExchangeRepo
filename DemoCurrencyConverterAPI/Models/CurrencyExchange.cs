using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoCurrencyConverterAPI.Models
{
    public class Rates
    {
        public double INR { get; set; }
    }

    public class CurrencyExchange
    {
        public string @base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }
    }    
}