﻿using System;
using System.Collections.Generic;
using System.Linq;
using
System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Spi;
using Microsoft.Extensions.Hosting;

namespace AgentMetricaComputer
{
    public class QuartzHostedService: IHostedService
    {

        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<JobSchedule> _jobSchedules;
        public IScheduler Scheduler { get; set; }



        public QuartzHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory, IEnumerable<JobSchedule> jobSchedules)
        {
            _schedulerFactory = schedulerFactory;
            _jobSchedules = jobSchedules;
            _jobFactory = jobFactory;

        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;
            foreach (var jobSchedule in _jobSchedules)
            {
                var job = CreateJobDetail(jobSchedule);
                var trigger = CreateTrigger(jobSchedule);
                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }
            await Scheduler.Start(cancellationToken);
        }


        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }


        private static IJobDetail CreateJobDetail(JobSchedule schedule)
        {
            var jobType = schedule.JobType;
            return JobBuilder
            .Create(jobType)
            .WithIdentity(jobType.FullName)
            .WithDescription(jobType.Name)
            .Build();
        }


        private static ITrigger CreateTrigger(JobSchedule schedule)
        {
            return TriggerBuilder
            .Create()
            .WithIdentity($"{schedule.JobType.FullName}.trigger")
            .WithCronSchedule(schedule.CronExcpression)
            .WithDescription(schedule.CronExcpression)
            .Build();
        }


        }
}
