using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenagerMertricaComputer.Controller
{
    [Route("api/metrics/network/from/{fromTime}/to/{toTime}/")]
    [ApiController]
    public class NetworkMenegerController : ControllerBase
    {
    }
}
