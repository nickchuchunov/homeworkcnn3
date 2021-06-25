﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace AgentMetricaComputer
{


    public class CpuAgentMetricaRepository : ICpuAgentMetricaRepository
    {
        private const string ConnectionString = "Data Source=metrics.db; Version=3;  Pooling=true; Max Pool Size=100;"; // Соединение с базой данных через конструктор 

        public void Create(CpuAgentMetrica item) // Создание таблицы  в базе данных и запись метрик  в таблицу
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "DROP TABLE IF EXISTS cpumetrica";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE cpumetrica( id INTEGER PRIMARY KEI, value INT, time INT)";
            cmd.CommandText = "INSERT INTO cpumetrica(value, time) VALUES (@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);

            long unixtime = 62168472000; // количество секунд на 1970 г.

            cmd.Parameters.AddWithValue("@time", (item.Time.Minute - unixtime));
            cmd.Prepare();
            cmd.ExecuteNonQuery();










        }

        public IList<CpuAgentMetrica> GetByTimePeriod() // чтение метрик из базы данных 
        {


            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM cpumetrica";
            var returnList = new List<CpuAgentMetrica>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    returnList.Add(new CpuAgentMetrica { Id = reader.GetInt32(0), Value = reader.GetInt32(1), Time = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(1)) });// Преобразует время в формате Unix, выраженное как количество секунд, истекших с 1970 в DateTimeOfset

                }

            }



            return returnList;









        }
    }
}