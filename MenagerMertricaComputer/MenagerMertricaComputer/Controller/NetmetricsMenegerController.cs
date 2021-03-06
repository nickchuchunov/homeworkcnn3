using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenagerMertricaComputer.Controller
{
    [Route("api/metrics/NetmetricsMenegerController")]
    [ApiController]
    public class NetmetricsMenegerController : ControllerBase
    {

        [Route("api/metrics/cpu//from/{fromTime}/to/{toTime}/")]
        [HttpGet("api/metrics/cpu//from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
        [Route("api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}")]
        [HttpGet("api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsByPercentileFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }


        [Route("api/metrics/network/from/{fromTime}/to/{toTime}/")]
        [HttpGet("api/metrics/network/from/{fromTime}/to/{toTime}/")]

        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }


        [Route("api/metrics/cpu/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        [HttpGet("api/metrics/cpu/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime, [FromRoute] Percentile percentile)
        {
            return Ok();
        }










    }
}
