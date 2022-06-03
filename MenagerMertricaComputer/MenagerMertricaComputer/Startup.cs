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



namespace MenagerMertricaComputer


{
    public class Startup
    {

        public const string connectionString = "Data Source = metricsmeneger.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            

            services.AddHttpClient<InterfaceMeneger, AcessAgent1>();

            services.AddFluentMigratorCore().ConfigureRunner(rb => rb.AddSQLite().WithGlobalConnectionString(connectionString).ScanIn(typeof(Startup).Assembly).For.Migrations()).AddLogging(lb => lb.AddFluentMigratorConsole());
            services.AddSingleton<InterfaceMeneger, AcessAgent1>();





            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<CpuMetricJob>();

            services.AddSingleton(new JobSchedule(jobType: typeof(CpuMetricJob), cronExcpression: "0 / 5 * *** ?"));





            services.AddSingleton<RamMetricJob>(); // RamMetricJob

            services.AddSingleton(new JobSchedule(jobType: typeof(RamMetricJob), cronExcpression: "0 / 5 * *** ?"));





            services.AddSingleton<NetworcMetricJob>(); // NetworkMetricJob

            services.AddSingleton(new JobSchedule(jobType: typeof(NetworcMetricJob), cronExcpression: "0 / 5 * *** ?"));



            services.AddSingleton<NetMetricJob>(); // NetMetricJob

            services.AddSingleton(new JobSchedule(jobType: typeof(NetMetricJob), cronExcpression: "0 / 5 * *** ?"));





            services.AddSingleton<HardDriveMetricJob>(); // HardDriveMetricJob

            services.AddSingleton(new JobSchedule(jobType: typeof(HardDriveMetricJob), cronExcpression: "0 / 5 * *** ?"));

            services.AddHostedService<QuartzHostedService>();









        }

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
    }
}
