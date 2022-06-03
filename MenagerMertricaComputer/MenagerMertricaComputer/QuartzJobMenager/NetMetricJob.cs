using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quartz;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;



namespace MenagerMertricaComputer
{
    public class NetMetricJob : IJob
    {

        public readonly AcessAgent1 _acessAgent1;






        NetMetricJob(AcessAgent1 acessAgent1)
        {
            _acessAgent1 = acessAgent1;

        }

        public Task Execute(IJobExecutionContext context)
        {





            DateTime time1 = DateTime.UtcNow;
            DateTime time2 = new DateTime(1970, 1, 1);
            int toParameter = 0;
            //определение параметра времени для опроса Агентов как maxзначение времени из базы Менеджера (ниже смю запрос к базе)
            string connectionString = "Data Source = metricsmeneger.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            string SQLCommand = "SELECT MAX(Time) FROM netmetrics";
            using (var connection = new SqliteConnection(connectionString))
            {

                connection.Open();
                SqliteCommand command = new SqliteCommand(SQLCommand, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read()) { }
                        toParameter = (int)reader.GetValue(0);

                    }

                    else { toParameter = (int)((time1.Ticks - time2.Ticks) / 10000000) - 6; };

                }

            };


            // определение параметра времени для опроса Агентов как текущее время в секундах с 1970 г.
            var fromParameter = (int)((time1.Ticks - time2.Ticks) / 10000000); // перевод в секунды с 1970 г время unix






            IList<DotNetMetricsMenegerMetrica> df = _acessAgent1.GetAllNetMetrics(new GetAllDotNetMetricsApiRequest { StartTimr = toParameter, EndTime = fromParameter });


            //Записать df в базу данных

            foreach (DotNetMetricsMenegerMetrica df1 in df)
            {
                string ConnectionString = "Data Source = metricsmeneger.db; Version = 3; Pooling = true; Max Pool Size = 100;";

                var connectionSQL = new SQLiteConnection(ConnectionString);
                connectionSQL.Open();
                var cmd = new SQLiteCommand(connectionSQL);
                cmd.CommandText = "INSERT INTO netmetrics(Id, Value, Time) VALUES(@Id, @Value, @Time)";
                cmd.Parameters.AddWithValue("@Id", df1.Id);
                cmd.Parameters.AddWithValue("@Value", df1.Value);
                cmd.Parameters.AddWithValue("@Time", df1.Time);







            }


            return Task.CompletedTask;










        }








    }
}
