using Infrastructure.Component.Shared.Certificate.Extension;
using Infrastructure.Component.Shared.CiCd.Extension;
using Infrastructure.Component.Shared.ContainerRegistry.Extension;
using Infrastructure.Component.Shared.Identity.Extension;
using Infrastructure.Component.Shared.Observability.Extension;
using Infrastructure.Component.Shared.Storage.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Component.Shared.Extension;

public static class ServiceCollectionExtension
{
    internal static IServiceCollection AddShared(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<SharedComponent>();

        serviceCollection.AddObservability();
        serviceCollection.AddStorageComponent();
        serviceCollection.AddContainerRegistry();
        serviceCollection.AddCICD();
        serviceCollection.AddCertificate();
        serviceCollection.AddIdentity();
        return serviceCollection;
    }
}