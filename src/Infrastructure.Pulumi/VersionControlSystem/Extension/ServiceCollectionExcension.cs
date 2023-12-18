using Infrastructure.Pulumi.VersionControlSystem.Resource.GiLab;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.VersionControlSystem.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddVersionControlSystem(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<VersionControlSystemComponent>();
            serviceCollection.AddScoped<GitLabResource>();
            return serviceCollection;
        }
    }
}