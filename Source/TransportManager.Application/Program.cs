using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TransportManager.Crosscutting.Helpers;
using TransportManager.Domain.DependencyInjectionExtensions;
using TransportManager.Services.DependencyInjectionExtensions;

namespace TransportManager.Application
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "Console App as a Service";

            await ExecuteMainAsync(args).ConfigureAwait(false);
        }

        private static async Task ExecuteMainAsync(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    // Call other providers here and call AddCommandLine last.
                    config.AddCommandLine(args, CommandLineHelper.GetKeyMappings());
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddSingleton<IHostedService, BackgroundHostedService>()
                        .AddServices()
                        .AddDomain();
                })
                .ConfigureLogging((hostContext, logging) =>
                {
                    logging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                });

            await builder.RunConsoleAsync().ConfigureAwait(false);
        }
    }
}
