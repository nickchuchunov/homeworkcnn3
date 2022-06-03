using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NLog.Web;


namespace AgentMetricaComputer
{
    public class Program
    {
        public static void Main(string[] args)
        {
        CreateHostBuilder(args).Build().Run();

            // Логирование

          var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
          try
          { logger.Debug("init main"); CreateHostBuilder(args).Build().Run(); }

            // отлов всех исключений в рамках работы приложения
         //  NLog: устанавливаем отлов исключений
           catch (Exception exception)

            { logger.Error(exception, "Stopped program because of exception"); throw; }

            // остановка логера
            finally
          { NLog.LogManager.Shutdown(); }



        
        static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
       {
           webBuilder.UseStartup<Startup>();
       })
       .ConfigureLogging(logging =>
       {
            logging.ClearProviders(); // создание провайдеров логирования
   logging.SetMinimumLevel(LogLevel.Trace);
       }).UseNLog(); // устанавливаем  минимальный уровень логирования

        // добавляем библиотеку nlog *




}

       public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
              {
                 webBuilder.UseStartup<Startup>();
               });

      

       



















    }
}
