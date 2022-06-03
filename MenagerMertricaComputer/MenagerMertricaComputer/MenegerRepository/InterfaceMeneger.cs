using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenagerMertricaComputer
{
   public interface InterfaceMeneger
    {
      public  IList<CpuMenegerMetrica>  GetAllCpuMetrics(GetAllCpuMetricsApiRequest request);
        public IList<HddMenegerMetrica> GetAllHddMetrics(GetAllHddMetricsApiRequest request);
        public IList<DotNetMetricsMenegerMetrica>  GetAllNetMetrics(GetAllDotNetMetricsApiRequest request);
        public IList<NetworcMenegerMetrica>  GetAllNetworcMetrics(GetAllNetvorcMetricsApiRequest request);
        public IList<RamMenegertMetrica> GetAllRamMetrics(GetAllRamMetricsApiRequest reguest);


    }
}
 