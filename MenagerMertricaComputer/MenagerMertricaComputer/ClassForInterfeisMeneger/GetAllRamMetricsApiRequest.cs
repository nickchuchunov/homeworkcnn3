﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenagerMertricaComputer
{
    public class GetAllRamMetricsApiRequest
    {
        public GetAllRamMetricsApiRequest() { }

        public int StartTimr { get; set; }
        public int EndTime { get; set; }
        public string URL = "https://localhost:44319/api/RamAgentController";


        


    }
}
