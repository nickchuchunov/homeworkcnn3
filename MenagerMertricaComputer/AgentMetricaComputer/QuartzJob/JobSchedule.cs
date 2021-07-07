using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentMetricaComputer
{
    
    public class JobSchedule
    {

        public Type JobType { get; }
        public string CronExcpression { get; }

     public   JobSchedule(Type jobType, string cronExcpression)
        {
            JobType = jobType;

            CronExcpression = cronExcpression;


        }

    }

}
