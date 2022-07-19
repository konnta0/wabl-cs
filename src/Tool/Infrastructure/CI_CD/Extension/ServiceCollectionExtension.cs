using Infrastructure.CI_CD.Resource.Tekton;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CI_CD.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddCICD(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ClusterRoleBinding>();
            serviceCollection.AddScoped<ServiceAccount>();
            serviceCollection.AddScoped<PipelineResource>();
            serviceCollection.AddScoped<TektonResource>();
            serviceCollection.AddScoped<CICDComponent>();
            serviceCollection.AddScoped<TektonTask>();
            serviceCollection.AddScoped<Pipeline>();
            serviceCollection.AddScoped<PipelineRun>();
            serviceCollection.AddScoped<TektonTaskRun>();
            return serviceCollection;
        }
    }
}