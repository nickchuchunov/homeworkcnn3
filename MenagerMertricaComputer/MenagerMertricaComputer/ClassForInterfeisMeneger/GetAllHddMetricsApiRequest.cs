﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenagerMertricaComputer
{
    public class GetAllHddMetricsApiRequest
    {

        public GetAllHddMetricsApiRequest() { }

        public int StartTimr { get; set; }
        public int EndTime { get; set; }
        public string URL = "https://localhost:44319/api/HardDriverAgentController";

    }
}
