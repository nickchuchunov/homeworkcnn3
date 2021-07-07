﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using Quartz.Spi;
using Microsoft.Extensions.DependencyInjection;

namespace AgentMetricaComputer
{
    public class SingletonJobFactory : IJobFactory
    {

        private readonly IServiceProvider _serviceProvider;
        public SingletonJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider; 
        
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {

            return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;

        }

        public void ReturnJob(IJob job) { }




    }
}
