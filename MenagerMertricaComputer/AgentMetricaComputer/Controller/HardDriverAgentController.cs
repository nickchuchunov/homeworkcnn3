using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog.Web;
using AutoMapper;

namespace AgentMetricaComputer
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardDriverAgentController : ControllerBase
    {


        private HardDriveAgentMetricaRepository repository; //!

        HardDriverAgentController(HardDriveAgentMetricaRepository repository) //
        {
            this.repository = repository;
        }



        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            repository.Create(new HardDriverAgentMetrica { Time = request.Time, Value = request.Value }); 
           


            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll(int id)
        {
            var config = new MapperConfiguration(ctf => ctf.CreateMap<HardDriverAgentMetrica, MetricDto>());
            var mapper = config.CreateMapper();


            var metrics = repository.GetByTimePeriod(id);
            var response = new MetricsResponse<MetricDto>
            {
                Metrics = new List<MetricDto>() //
            };
            foreach (var metric in metrics)
            {

                response.Metrics.Add(mapper.Map<MetricDto>(metric));

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
