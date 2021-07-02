using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;

using System.Data.SQLite;


namespace AgentMetricaComputer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuAgentController : ControllerBase
    {

        private CpuAgentMetricaRepository repository;

        CpuAgentController(CpuAgentMetricaRepository repository)
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
        public IActionResult GetAll(int id)
        {
            var config = new MapperConfiguration(ctf => ctf.CreateMap<CpuAgentMetrica, MetricDto>());
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



        public void LoggerCpuAgentController(ILogger LoggerCpuAgentController)
        {
            DateTime r = DateTime.Now;
            LoggerCpuAgentController.LogDebug(2, " Регистрация события  в указанное время " + r);
        }


        }
    }
