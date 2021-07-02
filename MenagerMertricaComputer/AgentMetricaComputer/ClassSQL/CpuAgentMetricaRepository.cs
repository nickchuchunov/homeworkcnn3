using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
namespace AgentMetricaComputer
{


    public class CpuAgentMetricaRepository : ICpuAgentMetricaRepository
    {
        private const string ConnectionString = "Data Source=metrics.db; Version=3;  Pooling=true; Max Pool Size=100;"; // Соединение с базой данных через конструктор 

        public void Create(CpuAgentMetrica item) // Создание таблицы  в базе данных и запись метрик  в таблицу
        {


            using (var connection = new SQLiteConnection(ConnectionString))
            {


               
                connection.Execute("CREATE TABLE cpumetrica( id INTEGER PRIMARY KEI, value INT, time INTEGER)", new { value = item.Value, time = item.Time });

            }


        }

        public IList<CpuAgentMetrica> GetByTimePeriod(int id) // чтение метрик из базы данных 
        {


            using (var connection = new SQLiteConnection(ConnectionString))

            {
                return connection.QuerySingle<System.Collections.Generic.IList<CpuAgentMetrica>>("SELECT Id, Time, Value FROM cpumetrica WHERE id=@id", new { id = id });
            }


           



        }
    }
}
