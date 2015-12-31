using DemoCurrencyConverterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoCurrencyConverterAPI.Controllers;

namespace DemoCurrencyConverterAPI.Controllers
{    
    public class ExchangeController : ApiController
    {
        private ExchangeRepository objExchangeRepository;
        public ExchangeController()
        {
            this.objExchangeRepository = new ExchangeRepository();
        }

        [HttpPost]
        [Route("api/v0/getINRRate")]
        public HttpResponseMessage Post(ExchangeRequest request)
        {
            if (ModelState.IsValid)
            {
                if (request == null)
                {
                    request = new ExchangeRequest();
                    request.CurrencyCode = "USD";
                    request.Amount = 1.0;
                }
                Exchange objExchange = this.objExchangeRepository.GetExchangeRate(request);

                ExchangeResponse objExchangeResponse = new ExchangeResponse();
                try
                {
                    if (objExchange != null)
                    {
                        objExchangeResponse.SourceCurrency = objExchange.SourceCurrency;
                        objExchangeResponse.ConversionRate = Math.Round(objExchange.ConversionRate, 2);
                        objExchangeResponse.Amount = request.Amount;
                        objExchangeResponse.Total = Math.Round(objExchange.ConversionRate, 2) * request.Amount;
                        objExchangeResponse.TimeStamp = objExchange.TimeStamp;
                        objExchangeResponse.ReturnCode = "1";
                        objExchangeResponse.Error = "Success";
                        return Request.CreateResponse(System.Net.HttpStatusCode.OK, objExchangeResponse); ;
                    }
                    else {
                        return Request.CreateResponse(HttpStatusCode.NotFound,"Requested currency code does not found");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ex.Message);                     
                }
            }
            else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
           
        }
        public void Post()
        {
           
        }
    }
}
