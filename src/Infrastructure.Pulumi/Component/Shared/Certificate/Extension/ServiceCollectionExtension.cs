using Infrastructure.Pulumi.Component.Shared.Certificate.CertManager;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.Component.Shared.Certificate.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddCertificate(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<CertManagerComponent>();
            serviceCollection.AddScoped<CertificateComponent>();
            return serviceCollection;
        }
    }
}