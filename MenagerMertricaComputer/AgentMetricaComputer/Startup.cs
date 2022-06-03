using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using AutoMapper;
using FluentMigrator.Runner;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

using Microsoft.Extensions.DependencyInjection;

namespace AgentMetricaComputer
{
    public class Startup
    {
       public const string connectionString = "Data Source = metrics.db; Version = 3; Pooling = true; Max Pool Size = 100;";


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



       



   


         void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
          
                services.AddSingleton<INetMetricsAgentMetricaRepository, NetMetricsAgentMetricaRepository>();    
                services.AddSingleton<INetworkAgentMetricaRepository, NetworkAgentMetricaRepository>();
                services.AddSingleton<IRamAgentMetricaRepository, RamAgentMetricaRepository>();
                services.AddSingleton<ICpuAgentMetricaRepository, CpuAgentMetricaRepository>();
                services.AddSingleton<IHardDriveAgentMetricaRepository, HardDriveAgentMetricaRepository>();


            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);


            services.AddFluentMigratorCore().ConfigureRunner(rb => rb.AddSQLite().WithGlobalConnectionString(connectionString).ScanIn(typeof(Startup).Assembly).For.Migrations()).AddLogging(lb => lb.AddFluentMigratorConsole());





            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<CpuMetricJob>();

            services.AddSingleton(new JobSchedule(jobType: typeof(CpuMetricJob), cronExcpression: "0 / 5 * *** ?")) ;



            

            services.AddSingleton<RamMetricJob>(); // RamMetricJob

            services.AddSingleton(new JobSchedule(jobType: typeof(RamMetricJob), cronExcpression: "0 / 5 * *** ?")); 



           

            services.AddSingleton<NetworkMetricJob>(); // NetworkMetricJob

            services.AddSingleton(new JobSchedule(jobType: typeof(NetworkMetricJob), cronExcpression: "0 / 5 * *** ?")); 


           
            services.AddSingleton<NetMetricJob>(); // NetMetricJob

            services.AddSingleton(new JobSchedule(jobType: typeof(NetMetricJob), cronExcpression: "0 / 5 * *** ?")); 



            

            services.AddSingleton<HardDriveMetricJob>(); // HardDriveMetricJob

            services.AddSingleton(new JobSchedule(jobType: typeof(HardDriveMetricJob), cronExcpression: "0 / 5 * *** ?"));

            services.AddHostedService<QuartzHostedService>();
           


        }







    }






}
