using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AgentMetricaComputer
{
    public class MapperProfile: Profile
    {
        public MapperProfile() 
        {
            CreateMap<NetworkAgentMetrica, NetworkMetricDto>();
            CreateMap<RamAgentMetrica, RamMetricDto>(); 
            CreateMap<NetMetricsAgentMetrica, NetMetricDto>();  
            CreateMap<HardDriverAgentMetrica, HardMetricDto>(); 
            CreateMap<CpuAgentMetrica, CpuMetricDto>(); 




        }
       







    }
}
