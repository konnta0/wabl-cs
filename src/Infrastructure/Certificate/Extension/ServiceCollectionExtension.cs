using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Certificate.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddCertificate(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<CertManager>();
            serviceCollection.AddScoped<CertificateComponent>();
            return serviceCollection;
        }
    }
}