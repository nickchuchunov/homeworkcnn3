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
    public class RamAgentController : ControllerBase
    {

        private IRamAgentMetricaRepository repository; //!

        RamAgentController(IRamAgentMetricaRepository repository) //
        {
            this.repository = repository;
        }



        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            repository.Create(new RamAgentMetrica { Time = request.Time, Value = request.Value }); //
            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetByTimePeriod();
            var response = new MetricsResponse<RamAgentMetrica> //
            {
                Metrics = new List<RamAgentMetrica>() //
            };
            foreach (var metric in metrics)
            {

                object gfh = new MetricDto { Id = metric.Id, Value = metric.Value, Time = metric.Time };



                response.Metrics.Add((RamAgentMetrica)gfh); //




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
