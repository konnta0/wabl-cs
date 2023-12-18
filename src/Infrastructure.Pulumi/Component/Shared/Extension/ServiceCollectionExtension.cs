using Infrastructure.Pulumi.Component.Shared.Certificate.Extension;
using Infrastructure.Pulumi.Component.Shared.CiCd.Extension;
using Infrastructure.Pulumi.Component.Shared.ContainerRegistry.Extension;
using Infrastructure.Pulumi.Component.Shared.Identity.Extension;
using Infrastructure.Pulumi.Component.Shared.Observability.Extension;
using Infrastructure.Pulumi.Component.Shared.Storage.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.Component.Shared.Extension;

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