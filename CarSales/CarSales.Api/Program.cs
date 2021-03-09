using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using CarSales.Persistence;

namespace CarSales.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();
            MigrateDatabase(host);
            host.Run();
        }

        private static void MigrateDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CarSalesContext>();
                db.Database.Migrate();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            
            .ConfigureAppConfiguration((context, config) =>
            {
                var env = context.HostingEnvironment;

                if (!env.IsDevelopment())
                {
                    // Add parameters              
                    config.AddEnvironmentVariables($"/vehicles/{env.EnvironmentName}");
                }
            })

            .UseStartup<Startup>();

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
