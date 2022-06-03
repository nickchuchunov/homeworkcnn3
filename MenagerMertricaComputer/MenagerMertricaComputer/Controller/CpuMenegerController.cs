using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Data.SQLite;

namespace MenagerMertricaComputer.Controller
{
    [Route("api/metrics/CpuMenegerController")]
    [ApiController]
    public class CpuMenegerController : ControllerBase
    {

        
        public ILogger MenegerController; // объект для логирования

        void LoggerMenager(ILogger LoggerCpuMenegerController, object agentId) // функция логирования входных аргументов
        {
            object agentIdlog =null ;

            while (agentId != agentIdlog) { DateTime r = DateTime.Now; agentIdlog = agentId; LoggerCpuMenegerController.LogDebug(2, "Метод EnableAgentById, Входной параметр agentId  " + agentId + " " + r); }

        }



       
        [HttpGet("/from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] int fromTime, [FromRoute] int toTime)
        {

            string connectionString = "Data Source = metricsmeneger.db; Version = 3; Pooling = true; Max Pool Size = 100;";

            List<SqlCpuMenegerMetrica> SqlList = new List<SqlCpuMenegerMetrica>();

            using (var connection = new SQLiteConnection(connectionString)) 
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))

                {

                   string read = "SELECT * FROM cpumetrica WHERE AgentId = @AgentId, Time>@Time1, Time<@Time2";

                    command.Parameters.AddWithValue("@AgentId", agentId);
                    command.Parameters.AddWithValue("@Time1", fromTime);
                    command.Parameters.AddWithValue("@Time2", toTime);
                    command.CommandText = read;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SqlCpuMenegerMetrica AddList = new SqlCpuMenegerMetrica();

                            AddList.Id = reader.GetInt32(0);
                            AddList.Value = reader.GetInt32(1);
                            AddList.Time = reader.GetInt32(2);
                            AddList.AgentId = reader.GetInt32(3);


                            SqlList.Add(AddList);


                        }



                    }






                }



            LoggerMenager(MenegerController, agentId);  // Логироввание

            return Ok(SqlList);
        }
        
        


       
        [HttpGet("api/metrics/network/from/{fromTime}/to/{toTime}/")]

        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime )
        {

            LoggerMenager(MenegerController, fromTime);  // Логироввание

            return Ok();
        }


        
       



        


        




    }
}
