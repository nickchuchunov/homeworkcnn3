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
    public class RamAgentController : ControllerBase
    {

        private RamAgentMetricaRepository repository;
        private readonly IMapper mapper;


        RamAgentController(RamAgentMetricaRepository repository, IMapper mapper) 
        {
            this.repository = repository;
            this.mapper = mapper;

        }



        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            repository.Create(new RamAgentMetrica { Time = request.Time, Value = request.Value });

            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll(int id)
        {
            

            var metrics = repository.GetByTimePeriod(id);
            var response = new MetricsResponse<RamMetricDto>
            {
                Metrics = new List<RamMetricDto>() //
            };
            foreach (var metric in metrics)
            {

                response.Metrics.Add(mapper.Map<RamMetricDto>(metric));



            }
            return Ok(response);
        }



        // логирование


        public void LoggerRamAgent(ILogger LoggerRamAgent)
        {
            DateTime r = DateTime.Now;
            LoggerRamAgent.LogDebug(2, " Регистрация события  в указанное время " + r);

        }

    }
}
