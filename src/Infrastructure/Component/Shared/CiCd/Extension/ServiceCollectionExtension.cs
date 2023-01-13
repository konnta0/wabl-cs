using Infrastructure.Component.Shared.CiCd;
using Infrastructure.Component.Shared.CiCd.Tekton;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CI_CD.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddCICD(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<TektonComponent>();
            serviceCollection.AddScoped<CiCdComponent>();
            serviceCollection.AddScoped<TektonTask>();
            serviceCollection.AddScoped<Pipeline>();
            serviceCollection.AddScoped<PipelineRun>();
            serviceCollection.AddScoped<TektonTaskRun>();
            return serviceCollection;
        }
    }
}