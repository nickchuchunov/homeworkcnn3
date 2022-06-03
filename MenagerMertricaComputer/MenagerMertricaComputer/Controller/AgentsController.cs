using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MenagerMertricaComputer.Controller
{
    [Route("api/metrics/AgentsController")]
    [ApiController]
    public class AgentsController : ControllerBase
    {

        public ILogger LoggerCpuMenegerController;

        
        void LoggerMenager(ILogger LoggerCpuMenegerController, object agentId) // функция логирования входных аргументов

        {
            object agentIdlog = null;
            while (agentId != agentIdlog) { DateTime r = DateTime.Now; agentIdlog = agentId; LoggerCpuMenegerController.LogDebug(2, "Метод EnableAgentById, Входной параметр agentId  " + agentId + " " + r); }

        }


        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {

            LoggerMenager(LoggerCpuMenegerController, agentInfo);

            return Ok();
        }


        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId, ILogger LoggerAgentsController)
        {

            LoggerMenager(LoggerCpuMenegerController, agentId);

            return Ok();
        }
        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId, ILogger  LoggerAgentsController)
        {

            LoggerMenager(LoggerCpuMenegerController, agentId);

            return Ok();


        }





     









       







    }
}
