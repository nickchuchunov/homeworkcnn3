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
    [Route("api/CpuAgentController")]
    [ApiController]
    public class CpuAgentController : ControllerBase
    {

        private CpuAgentMetricaRepository repository;
        private readonly IMapper mapper;

        CpuAgentController(CpuAgentMetricaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpGet("{fromParameter}/to/{toParameter}")]
        public IActionResult GetAll([FromRoute] int fromParameter, [FromRoute] int toParameter)
        {
           

            var metrics = repository.GetByTimePeriod(fromParameter, toParameter);
            var response = new MetricsResponse<CpuMetricDto>
            {
                Metrics = new List<CpuMetricDto>() //
            };
            foreach (var metric in metrics)
            {

                response.Metrics.Add(mapper.Map<CpuMetricDto>(metric));

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
