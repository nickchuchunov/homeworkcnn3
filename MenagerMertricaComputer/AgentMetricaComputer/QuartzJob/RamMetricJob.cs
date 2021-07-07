using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;

namespace AgentMetricaComputer
{
    public class RamMetricJob: IJob
    {
        private IRamAgentMetricaRepository _repository;
        private PerformanceCounter _ramCounter;
        public RamMetricJob (IRamAgentMetricaRepository repository)
        {
            _repository = repository;

            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            

        }

        public Task Execute (IJobExecutionContext context)

        {


            var ramUsageInPercents = Convert.ToInt32(_ramCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new RamAgentMetrica
            {


                Time =(int) time.Ticks,
                Value = ramUsageInPercents
            });


            return Task.CompletedTask;



        }





    }
}
