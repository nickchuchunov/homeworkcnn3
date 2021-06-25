using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using System.Data.SQLite;


namespace AgentMetricaComputer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuAgentController : ControllerBase
    {

        private ICpuAgentMetricaRepository repository;

        CpuAgentController(ICpuAgentMetricaRepository repository)
        {
            this.repository = repository;
        }



        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
         repository.Create(new CpuAgentMetrica { Time = request.Time, Value = request.Value });
            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetByTimePeriod();
            var response = new MetricsResponse<CpuAgentMetrica>
            {
                Metrics = new List<CpuAgentMetrica>()
            };
            foreach (var metric in metrics)
            {

                object gfh = new MetricDto { Id = metric.Id, Value = metric.Value, Time = metric.Time };



                response.Metrics.Add((CpuAgentMetrica)gfh);
               



            }
            return Ok(response);
        }






        // логирование



        public void LoggerCpuAgentController(ILogger LoggerCpuAgentController)
        {
            DateTime r = DateTime.Now;
            LoggerCpuAgentController.LogDebug(2, " Регистрация события  в указанное время " + r);
        }












        }
    }
