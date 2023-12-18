using Infrastructure.Pulumi.Component.Shared.CiCd.GitHubActions;
using Infrastructure.Pulumi.Component.Shared.CiCd.Spinnaker;
using Infrastructure.Pulumi.Component.Shared.CiCd.Tekton;
using Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.EventListener;
using Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.Pipeline;
using Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.PipelineRun;
using Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.Task;
using Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.TaskRun;
using Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.TriggerBinding;
using Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.TriggerTemplate;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Extension
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