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
    public class NetMetricJob : IJob
    {
        private INetMetricsAgentMetricaRepository _repository;
        private PerformanceCounter _netCounter;
        public NetMetricJob(INetMetricsAgentMetricaRepository repository)
        {
            _repository = repository;

            _netCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");



        }

        public Task Execute(IJobExecutionContext context)

        {

            var netUsageInPercents = Convert.ToInt32(_netCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new NetMetricsAgentMetrica
            {


                Time =(int) time.Ticks,
                Value = netUsageInPercents
            });


            return Task.CompletedTask;




        }




    }
}
