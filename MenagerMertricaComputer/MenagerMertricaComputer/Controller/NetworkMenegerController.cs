using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MenagerMertricaComputer.Controller
{
    [Route("api/metrics/NetworkMenegerController")]
    [ApiController]
    public class NetworkMenegerController : ControllerBase
    {


        public ILogger MenegerController; // объект для логирования

        void LoggerMenager(ILogger LoggerCpuMenegerController, object agentId) // функция логирования входных аргументов
        {
            object agentIdlog = null;

            while (agentId != agentIdlog) { DateTime r = DateTime.Now; agentIdlog = agentId; LoggerCpuMenegerController.LogDebug(2, "Метод EnableAgentById, Входной параметр agentId  " + agentId + " " + r); }


        }





        
        [HttpGet("api/metrics/cpu//from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {


            LoggerMenager(MenegerController, agentId);

            return Ok();
        }
        
       

        
        [HttpGet("api/metrics/network/from/{fromTime}/to/{toTime}/")]

        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {

            LoggerMenager(MenegerController, fromTime);
            return Ok();
        }


        
        














    }
}
