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
    public class NetworkAgentController : ControllerBase
    {

        private INetworkAgentMetricaRepository repository; //!

        NetworkAgentController(INetworkAgentMetricaRepository repository) //
        {
            this.repository = repository;
        }



        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            repository.Create(new NetworkAgentMetrica { Time = request.Time, Value = request.Value }); //
            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetByTimePeriod();
            var response = new MetricsResponse<NetworkAgentMetrica> //
            {
                Metrics = new List<NetworkAgentMetrica>() //
            };
            foreach (var metric in metrics)
            {

                object gfh = new MetricDto { Id = metric.Id, Value = metric.Value, Time = metric.Time };



                response.Metrics.Add((NetworkAgentMetrica)gfh); //




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
