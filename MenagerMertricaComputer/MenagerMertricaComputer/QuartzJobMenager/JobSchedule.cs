using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quartz;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;



namespace MenagerMertricaComputer
{
    public class JobSchedule
    {
        public Type JobType { get; }
        public string CronExcpression { get; }

        public JobSchedule(Type jobType, string cronExcpression)
        {
            JobType = jobType;

            CronExcpression = cronExcpression;


        }


    }
}
