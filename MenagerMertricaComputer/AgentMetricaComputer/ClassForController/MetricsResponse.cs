using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentMetricaComputer
{
    public class MetricsResponse<T>
    {

        public MetricsResponse() { }

        public List<T> Metrics { get; set; }




    }
}
