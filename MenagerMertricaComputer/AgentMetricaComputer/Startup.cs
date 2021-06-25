using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AgentMetricaComputer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
      
        }



        private void PrepareSchema(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                // задаем новый текст команды для выполнения
                // удаляем таблицу с метриками если она существует в базе данных
                command.CommandText = "DROP TABLE IF EXISTS netmetrics";
                // отправляем запрос в базу данных
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE netmetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();


                command.CommandText = "DROP TABLE IF EXISTS networkmetrica";// 
                // отправляем запрос в базу данных
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE networkmetrica(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();



                command.CommandText = "DROP TABLE IF EXISTS rammetrica";//  
                // отправляем запрос в базу данных
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE rammetrica(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();




                command.CommandText = "DROP TABLE IF EXISTS cpumetrica";
                // отправляем запрос в базу данных
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE cpumetrica(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();




                command.CommandText = "DROP TABLE IF EXISTS harddrivemetrica";//  
                // отправляем запрос в базу данных
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE harddrivemetrica(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();






            }



        }



            void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            const string connectionString = "Data Source = metrics.db; Version = 3; Pooling = true; Max Pool Size = 100; ";
var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }



         void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureSqlLiteConnection(services);
            services.AddScoped<INetMetricsAgentMetricaRepository, NetMetricsAgentMetricaRepository>();    
                services.AddScoped<INetworkAgentMetricaRepository, NetworkAgentMetricaRepository>();
                services.AddScoped<IRamAgentMetricaRepository, RamAgentMetricaRepository>();
                services.AddScoped<ICpuAgentMetricaRepository, CpuAgentMetricaRepository>();
                services.AddScoped<IHardDriveAgentMetricaRepository, HardDriveAgentMetricaRepository>();


         }







    }






}
