using System.Threading.Tasks;
using Infrastructure.Component.Shared;
using Infrastructure.Component.Shared.Certificate.Extension;
using Infrastructure.Component.Shared.CiCd.Extension;
using Infrastructure.Component.Shared.ContainerRegistry.Extension;
using Infrastructure.Component.Shared.Storage.Extension;
using Infrastructure.Component.Tool.Extension;
using Infrastructure.Component.WebApplication.Extension;
using Infrastructure.Resource.Shared.Observability.Extension;
using Infrastructure.Stack;
using Infrastructure.VersionControlSystem.Extension;
using Microsoft.Extensions.DependencyInjection;
using Pulumi;

class Program
{
    static Task<int> Main()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureService(serviceCollection);
        return Deployment.RunAsync<DevelopmentStack>(serviceCollection.BuildServiceProvider());
    }

    private static void ConfigureService(IServiceCollection serviceCollection)
    {
        serviceCollection.AddLogging();
        serviceCollection.AddSingleton<Config>();
        serviceCollection.AddCICD();
        serviceCollection.AddContainerRegistry();
        serviceCollection.AddObservability();
        serviceCollection.AddCertificate();
        serviceCollection.AddVersionControlSystem();
        serviceCollection.AddWebApplication();
        serviceCollection.AddTool();
        serviceCollection.AddStorageComponent();
        serviceCollection.AddScoped<DevelopmentStack>();
        serviceCollection.AddScoped<SharedComponent>();
    }
}
