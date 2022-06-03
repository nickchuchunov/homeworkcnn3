using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace AgentMetricaComputer
{
    [Route("api/NetMetricsAgentController")]
    [ApiController]
    public class NetMetricsAgentController : ControllerBase
    {


        private NetMetricsAgentMetricaRepository repository; //!
        private readonly IMapper mapper;

        NetMetricsAgentController(NetMetricsAgentMetricaRepository repository, IMapper mapper) //
        {
            this.repository = repository;
            this.mapper = mapper;
        }



        


        [HttpGet("{fromParameter}/to/{toParameter}")]
        public IActionResult GetAll([FromRoute] int fromParameter, [FromRoute] int toParameter)
        {
          


            var metrics = repository.GetByTimePeriod(fromParameter, toParameter);
            var response = new MetricsResponse<NetMetricDto>
            {
                Metrics = new List<NetMetricDto>() //
            };
            foreach (var metric in metrics)
            {

                response.Metrics.Add(mapper.Map<NetMetricDto>(metric));



            }
            return Ok(response);
        }


        // логирование


        public void LoggerNetMetricsAgent(ILogger LoggerNetMetricsAgent)
        {
            DateTime r = DateTime.Now;
            LoggerNetMetricsAgent.LogDebug(2, " Регистрация события  в указанное время " + r);

        }
  
    
    
    }
}