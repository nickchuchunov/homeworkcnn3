using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
namespace AgentMetricaComputer
{
    public class RamAgentMetricaRepository : IRamAgentMetricaRepository
    {

        private const string ConnectionString = "Data Source=metrics.db; Version=3;  Pooling=true; Max Pool Size=100;"; // Соединение с базой данных через конструктор 
        public void Create(RamAgentMetrica item) // Создание таблицы  в базе данных и запись метрик  в таблицу
        {

            using (var connection = new SQLiteConnection(ConnectionString))
            {
               

                
                connection.Execute("CREATE TABLE rammetrica( id INTEGER PRIMARY KEI, value INT, time INTEGER)", new { value = item.Value, time = item.Time });

            }
            


        }

        public IList<RamAgentMetrica> GetByTimePeriod(int id) // чтение метрик из базы данных 
        {

            using (var connection = new SQLiteConnection(ConnectionString))

            { 
                return connection.QuerySingle<System.Collections.Generic.IList<RamAgentMetrica>>("SELECT Id, Time, Value FROM rammetrica WHERE id=@id", new { id = id });
            }

          
            


        }
    }
}
