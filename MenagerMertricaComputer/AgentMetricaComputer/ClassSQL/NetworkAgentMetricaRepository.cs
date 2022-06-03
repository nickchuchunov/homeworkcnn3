using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
namespace AgentMetricaComputer
{
    public class NetworkAgentMetricaRepository : INetworkAgentMetricaRepository
    {

        private const string ConnectionString = "Data Source=metrics.db; Version=3;  Pooling=true; Max Pool Size=100;"; // Соединение с базой данных через конструктор 


        public void Create(NetworkAgentMetrica item) // Создание таблицы  в базе данных и запись метрик  в таблицу
        {

            using (var connection = new SQLiteConnection(ConnectionString))
            {

                
                connection.Execute("CREATE TABLE networkmetrica( id INTEGER PRIMARY KEI, value INT, time INT)", new { value = item.Value, time = item.Time  });

            }
           
        }


        


      public IEnumerable<NetworkAgentMetrica> GetByTimePeriod(int fromParameter, int toParameter) // чтение метрик из базы данных 
        {


            using (var connection = new SQLiteConnection(ConnectionString))

            {
                int i = fromParameter;
                IEnumerable<NetworkAgentMetrica> cpuagentmetrica = connection.QuerySingle<System.Collections.Generic.IEnumerable<NetworkAgentMetrica>>("SELECT Id, Time, Value FROM cpumetrica WHERE id=@id", new { Time = i });
                while (i <= toParameter)
                {
                    yield return (NetworkAgentMetrica)cpuagentmetrica;
                    i++;


                    continue;
                }
                yield return (NetworkAgentMetrica)cpuagentmetrica;
            }






        }



    }
}
