using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DemoCurrencyConverterAPI.Models
{
    public class ExchangeRequest
    {       
        [MinLength(3, ErrorMessage ="CurrencyCode Cannot be lesser than 3 characters")]
        [MaxLength(3,ErrorMessage ="CurrencyCode Cannot be greater than 3 characters")]
        public string CurrencyCode { get; set; }
        public double Amount { get; set; }
    }
}