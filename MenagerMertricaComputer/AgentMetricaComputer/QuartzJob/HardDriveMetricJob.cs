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
    public class HardDriveMetricJob : IJob
    {

        private IHardDriveAgentMetricaRepository _repository;
        private PerformanceCounter _harddriveCounter;
        public HardDriveMetricJob(IHardDriveAgentMetricaRepository repository)
        {
            _repository = repository;

            _harddriveCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");



        }

        public Task Execute(IJobExecutionContext context)

        {




            var harddriveUsageInPercents = Convert.ToInt32(_harddriveCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new HardDriverAgentMetrica
            {


                Time =(int) time.Ticks,
                Value = harddriveUsageInPercents
            });


            return Task.CompletedTask;

        }
    }
}
