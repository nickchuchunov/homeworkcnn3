using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentMetricaComputer
{
    public class CpuMetricDto 
    {

       public  CpuMetricDto() { }
        public int Id { get; set; }
        public int Value { get; set; }
        public int Time { get; set; } //  DateTimeOffset.FromUnixTimeSeconds(Time) }) Преобразует время в формате Unix, выраженное как количество секунд, истекших с 1970 в DateTimeOfset






    }
}
