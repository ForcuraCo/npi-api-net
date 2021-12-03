#if NETCOREAPP2_1_OR_GREATER

using Microsoft.Extensions.DependencyInjection;

namespace Forcura.NPPES.DependencyInjection
{
    /// <summary>
    /// Extensions for registering the <see cref="NPPESApiClient"/> with the <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the <see cref="NPPESApiClient"/> with the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The configured <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddNPPESApi(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<NPPESApiClient>();

            return serviceCollection;
        }
    }
}

#endif