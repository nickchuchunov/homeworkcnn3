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
    public class NetworkMetricJob : IJob
    {


        private INetworkAgentMetricaRepository _repository;
        private PerformanceCounter _networkCounter;
        public NetworkMetricJob(INetworkAgentMetricaRepository repository)
        {
            _repository = repository;

            _networkCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");



        }

        public Task Execute(IJobExecutionContext context)

        {




            var networkUsageInPercents = Convert.ToInt32(_networkCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new NetworkAgentMetrica
            { 


                Time =(int) time.Ticks,
                Value = networkUsageInPercents
            });


            return Task.CompletedTask;

        }



    }
}
