using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;

namespace AgentMetricaComputer
{
    public class NetMetricsAgentMetricaRepository : INetMetricsAgentMetricaRepository
    {

        private const string ConnectionString = "Data Source=metrics.db; Version=3;  Pooling=true; Max Pool Size=100;"; // Соединение с базой данных через конструктор 

        public void Create(NetMetricsAgentMetrica item) // Создание таблицы  в базе данных и запись метрик  в таблицу
        {

            using (var connection = new SQLiteConnection(ConnectionString))
            {

                
                connection.Execute("CREATE TABLE netmetrics( id INTEGER PRIMARY KEI, value INT, time INT", new { value = item.Value, time = item.Time  });

            }
  
        }


        public IList<NetMetricsAgentMetrica> GetByTimePeriod(int id) // чтение метрик из базы данных 
        {

            using (var connection = new SQLiteConnection(ConnectionString))

            {
                return connection.QuerySingle<System.Collections.Generic.IList<NetMetricsAgentMetrica>>("SELECT Id, Time, Value FROM netmetrics WHERE id=@id", new { id = id });
            }

            //        returnList.Add(new RamAgentMetrica { Id = reader.GetInt32(0), Value = reader.GetInt32(1), Time = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(1)) });// Преобразует время в формате Unix, выраженное как количество секунд, истекших с 1970 в DateTimeOfset


        }
    }
}
