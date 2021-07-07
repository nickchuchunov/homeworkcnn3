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


        private HardDriveAgentMetricaRepository repository;
        private readonly IMapper mapper;

        HardDriverAgentController(HardDriveAgentMetricaRepository repository, IMapper mapper) //
        {
            this.repository = repository;
            this.mapper = mapper;
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
            

            var metrics = repository.GetByTimePeriod(id);
            var response = new MetricsResponse<HardMetricDto>
            {
                Metrics = new List<HardMetricDto>() //
            };
            foreach (var metric in metrics)
            {

                response.Metrics.Add(mapper.Map<HardMetricDto>(metric));

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
