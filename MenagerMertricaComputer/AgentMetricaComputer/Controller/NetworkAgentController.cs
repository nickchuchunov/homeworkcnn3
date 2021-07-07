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
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkAgentController : ControllerBase
    {

        private NetworkAgentMetricaRepository repository;
        private readonly IMapper mapper;


        NetworkAgentController(NetworkAgentMetricaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            repository.Create(new NetworkAgentMetrica { Time = request.Time, Value = request.Value });

            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll(int id)
        {

            

            var metrics = repository.GetByTimePeriod(id);
            var response = new MetricsResponse<NetworkMetricDto> 
            {
                Metrics = new List<NetworkMetricDto>() //
            };
            foreach (var metric in metrics)
            {

                response.Metrics.Add(mapper.Map<NetworkMetricDto>(metric));



            }
            return Ok(response);
        }


        // логирование


        public void LoggerNetworkAgent(ILogger LoggerNetworkAgent)
        {
            DateTime r = DateTime.Now;
            LoggerNetworkAgent.LogDebug(2, " Регистрация события  в указанное время " + r);

        }

    }
}
