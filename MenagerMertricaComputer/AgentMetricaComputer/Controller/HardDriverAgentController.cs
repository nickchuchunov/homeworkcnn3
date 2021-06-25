using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog.Web;


namespace AgentMetricaComputer
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardDriverAgentController : ControllerBase
    {


        private IHardDriveAgentMetricaRepository repository; //!

        HardDriverAgentController(IHardDriveAgentMetricaRepository repository) //
        {
            this.repository = repository;
        }



        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            repository.Create(new HardDriverAgentMetrica { Time = request.Time, Value = request.Value }); //
            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetByTimePeriod();
            var response = new MetricsResponse<HardDriverAgentMetrica> //
            {
                Metrics = new List<HardDriverAgentMetrica>() //
            };
            foreach (var metric in metrics)
            {

                object gfh = new MetricDto { Id = metric.Id, Value = metric.Value, Time = metric.Time };



                response.Metrics.Add((HardDriverAgentMetrica)gfh); //




            }
            return Ok(response);
        }













        // логирование

        public void LoggerHardDriverAgentController(ILogger LoggerHardDriverAgent)
        {
        DateTime r = DateTime.Now;
            LoggerHardDriverAgent.LogDebug(2, " Регистрация события  в указанное время "+r);


        }


    }
}
