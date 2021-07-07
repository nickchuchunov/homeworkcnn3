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
    public class NetMetricsAgentController : ControllerBase
    {


        private NetMetricsAgentMetricaRepository repository; //!
        private readonly IMapper mapper;

        NetMetricsAgentController(NetMetricsAgentMetricaRepository repository, IMapper mapper) //
        {
            this.repository = repository;
            this.mapper = mapper;
        }



        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            repository.Create(new NetMetricsAgentMetrica { Time = request.Time, Value = request.Value }); //

           




            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll(int id)
        {
          


            var metrics = repository.GetByTimePeriod(id);
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