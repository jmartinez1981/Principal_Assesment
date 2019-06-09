using Microsoft.Extensions.DependencyInjection;
using TransportManager.Services.Factory;
using TransportManager.Services.Strategy;

namespace TransportManager.Services.DependencyInjectionExtensions
{
    public static class SimpleInjectorContainerExtensions
    {
        /// <summary>
        /// Registers services dependency injection.
        /// </summary>
        /// <param name="services">The service collection instance.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IOperationCoordinator, OperationCoordinator>();

            // Register strategies
            services.AddScoped<IOperationStrategy, ArriveSampleOperation>();
            services.AddScoped<IOperationStrategy, StoreSampleMinPriorityOperation>();
            services.AddScoped<IOperationStrategy, StoreSampleMaxPriorityOperation>();
            services.AddScoped<IOperationStrategy, LeftSampleOperation>();

            // Register Factory
            services.AddSingleton<IOperationFactory, OperationFactory>();

            return services;
        }
    }
}
