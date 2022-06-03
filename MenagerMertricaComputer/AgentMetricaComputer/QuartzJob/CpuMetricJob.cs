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
    public class CpuMetricJob : IJob
    {

        private CpuAgentMetricaRepository _repository;

        private PerformanceCounter _cpuCounter;

        public CpuMetricJob(CpuAgentMetricaRepository repository)
        {
            _repository = repository;

            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");


        }

        public Task Execute(IJobExecutionContext context)

        {
           

            var cpuUsageInPercents = Convert.ToInt32(_cpuCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new CpuAgentMetrica
            {

                
                Time =(int) time.Ticks,
                Value = cpuUsageInPercents
                
        }) ;

           

            return Task.CompletedTask;

        }







    }
}
