﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenagerMertricaComputer
{
    public class SqlRamMenegerMetrica
    {
        public SqlRamMenegerMetrica() { }
        public int Id { get; set; }
        public int Value { get; set; }
        public int Time { get; set; }
        public int AgentId { get; set; }

    }
}
