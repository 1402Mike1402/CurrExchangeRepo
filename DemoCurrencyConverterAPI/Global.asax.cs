using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Quartz.Impl;
using Quartz;
using Swashbuckle.Application;

namespace DemoCurrencyConverterAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);            
            Scheduler();
        }

        private void Scheduler()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler();

            IJobDetail jobDetail = JobBuilder.Create<CurrencyExchangeJob>()
                .WithIdentity("CurrencyExchangeJob")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .ForJob(jobDetail)
                .WithCronSchedule("0 0/1 * * * ?")
                .WithIdentity("CurrencyExchangeJob")
                .StartNow()
                .Build();
            scheduler.ScheduleJob(jobDetail, trigger);
            scheduler.Start();
        }
    }
}
