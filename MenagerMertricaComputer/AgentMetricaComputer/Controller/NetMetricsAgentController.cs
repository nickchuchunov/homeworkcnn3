using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AgentMetricaComputer
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetMetricsAgentController : ControllerBase
    {


        private INetMetricsAgentMetricaRepository repository; //!

        NetMetricsAgentController(INetMetricsAgentMetricaRepository repository) //
        {
            this.repository = repository;
        }



        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            repository.Create(new NetMetricsAgentMetrica { Time = request.Time, Value = request.Value }); //
            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetByTimePeriod();
            var response = new MetricsResponse<NetMetricsAgentMetrica> //
            {
                Metrics = new List<NetMetricsAgentMetrica>() //
            };
            foreach (var metric in metrics)
            {

                object gfh = new MetricDto { Id = metric.Id, Value = metric.Value, Time = metric.Time };



                response.Metrics.Add((NetMetricsAgentMetrica)gfh); //




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