using Infrastructure.Component.Shared.CiCd.GitHubActions;
using Infrastructure.Component.Shared.CiCd.Spinnaker;
using Infrastructure.Component.Shared.CiCd.Tekton;
using Infrastructure.Component.Shared.CiCd.Tekton.EventListener;
using Infrastructure.Component.Shared.CiCd.Tekton.Pipeline;
using Infrastructure.Component.Shared.CiCd.Tekton.PipelineRun;
using Infrastructure.Component.Shared.CiCd.Tekton.Task;
using Infrastructure.Component.Shared.CiCd.Tekton.TaskRun;
using Infrastructure.Component.Shared.CiCd.Tekton.TriggerBinding;
using Infrastructure.Component.Shared.CiCd.Tekton.TriggerTemplate;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Component.Shared.CiCd.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddCICD(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<CiCdComponent>();

            serviceCollection.AddScoped<GitHubActionsComponent>();
            serviceCollection.AddScoped<TektonComponent>();
            serviceCollection.AddScoped<TektonTaskComponent>();
            serviceCollection.AddScoped<PipelineComponent>();
            serviceCollection.AddScoped<PipelineRunComponent>();
            serviceCollection.AddScoped<TektonTaskRunComponent>();
            serviceCollection.AddScoped<TriggerTemplateComponent>();
            serviceCollection.AddScoped<TriggerBindingComponent>();
            serviceCollection.AddScoped<EventListenerComponent>();

            serviceCollection.AddScoped<SpinnakerComponent>();
            return serviceCollection;
        }
    }
}