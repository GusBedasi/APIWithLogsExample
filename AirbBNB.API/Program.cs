using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AirbBNB.API
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                var hostBuilder = CreateHostBuilder(args).Build();
                Log.Information("Iniciando web host");
                hostBuilder.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host encerrado inesperadament");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.Seq("http://localhost:5341")
                        .CreateLogger();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}