using Infrastructure.Pulumi.Component.Shared.Identity.Keycloak;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.Component.Shared.Identity.Extension;

internal static class ServiceCollectionExtension
{
    internal static IServiceCollection AddIdentity(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IdentityComponent>();
        serviceCollection.AddScoped<KeycloakComponent>();
        return serviceCollection;
    }
}