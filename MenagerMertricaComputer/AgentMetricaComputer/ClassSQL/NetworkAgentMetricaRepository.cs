using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace AgentMetricaComputer
{
    public class NetworkAgentMetricaRepository : INetworkAgentMetricaRepository
    {

        private const string ConnectionString = "Data Source=metrics.db; Version=3;  Pooling=true; Max Pool Size=100;"; // Соединение с базой данных через конструктор 


        public void Create(NetworkAgentMetrica item) // Создание таблицы  в базе данных и запись метрик  в таблицу
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "DROP TABLE IF EXISTS networkmetrica";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE networkmetrica( id INTEGER PRIMARY KEI, value INT, time INT)";
            cmd.CommandText = "INSERT INTO networkmetrica(value, time) VALUES (@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);
            long unixtime = 62168472000; // количество секунд на 1970 г.

            cmd.Parameters.AddWithValue("@time", (item.Time.Minute - unixtime));

            cmd.Prepare();
            cmd.ExecuteNonQuery();

           
        }

        public IList<NetworkAgentMetrica> GetByTimePeriod() // чтение метрик из базы данных 
        {


            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM networkmetrica";
            var returnList = new List<NetworkAgentMetrica>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    returnList.Add(new NetworkAgentMetrica { Id = reader.GetInt32(0), Value = reader.GetInt32(1), Time = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(1)) });// Преобразует время в формате Unix, выраженное как количество секунд, истекших с 1970 в DateTimeOfset

                }

            }



            return returnList;








        }
    }
}
