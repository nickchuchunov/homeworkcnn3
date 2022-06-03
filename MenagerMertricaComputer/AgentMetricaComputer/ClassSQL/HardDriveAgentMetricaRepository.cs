using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;

namespace AgentMetricaComputer
{
    public class HardDriveAgentMetricaRepository : IHardDriveAgentMetricaRepository
    {

        private const string ConnectionString = "Data Source=metrics.db; Version=3;  Pooling=true; Max Pool Size=100;"; // Соединение с базой данных через конструктор 


        public void Create(HardDriverAgentMetrica item) // Создание таблицы  в базе данных и запись метрик  в таблицу
        {

            using (var connection = new SQLiteConnection(ConnectionString))
            {


                connection.Execute("CREATE TABLE harddrivemetrica( id INTEGER PRIMARY KEI, value INT, time INT)", new { value = item.Value, time = item.Time });

            }


        }



        public IEnumerable<HardDriverAgentMetrica> GetByTimePeriod(int fromParameter, int toParameter) // чтение метрик из базы данных 
        {


            using (var connection = new SQLiteConnection(ConnectionString))

            {
                int i = fromParameter;
                IEnumerable<HardDriverAgentMetrica> cpuagentmetrica = connection.QuerySingle<System.Collections.Generic.IEnumerable<HardDriverAgentMetrica>>("SELECT Id, Time, Value FROM cpumetrica WHERE id=@id", new { Time = i });
                while (i <= toParameter)
                {
                    yield return (HardDriverAgentMetrica)cpuagentmetrica;
                    i++;


                    continue;
                }
                yield return (HardDriverAgentMetrica)cpuagentmetrica;
            }






        }

    }
}
