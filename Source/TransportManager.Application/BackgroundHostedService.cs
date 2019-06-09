using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TransportManager.Services;

namespace TransportManager.Application
{
    public class BackgroundHostedService : IHostedService
    {
        private readonly ILogger<BackgroundHostedService> logger;

        private readonly IOperationCoordinator operationCoordinator;

        public BackgroundHostedService(ILogger<BackgroundHostedService> logger, IOperationCoordinator operationCoordinator)
        {
            this.logger = logger;
            this.operationCoordinator = operationCoordinator;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("TransportManager Service is started");

            this.operationCoordinator.Execute();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("TransportManager Service is stopped");

            return Task.CompletedTask;
        }
    }
}
