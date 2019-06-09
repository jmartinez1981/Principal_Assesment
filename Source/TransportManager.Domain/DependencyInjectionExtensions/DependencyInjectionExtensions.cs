using Microsoft.Extensions.DependencyInjection;

namespace TransportManager.Domain.DependencyInjectionExtensions
{
    public static class SimpleInjectorContainerExtensions
    {
        /// <summary>
        /// Registers domain dependency injection.
        /// </summary>
        /// <param name="services">The service collection instance.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<ILaboratory, Laboratory>();

            return services;
        }
    }
}
