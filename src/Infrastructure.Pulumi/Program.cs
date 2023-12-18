using System.Threading.Tasks;
using Infrastructure.Pulumi.Component.Shared.Extension;
using Infrastructure.Pulumi.Component.Tool.Extension;
using Infrastructure.Pulumi.Component.WebApplication.Extension;
using Infrastructure.Pulumi.Stack;
using Infrastructure.Pulumi.VersionControlSystem.Extension;
using Microsoft.Extensions.DependencyInjection;
using Pulumi;

class Program
{
    static Task<int> Main()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureService(serviceCollection);
        return Deployment.RunAsync<LocalStack>(serviceCollection.BuildServiceProvider());
    }

    private static void ConfigureService(IServiceCollection serviceCollection)
    {
        serviceCollection.AddLogging();
        serviceCollection.AddSingleton<Config>();
        serviceCollection.AddVersionControlSystem();
        serviceCollection.AddWebApplication();
        serviceCollection.AddShared();
        serviceCollection.AddTool();
        serviceCollection.AddScoped<LocalStack>();
    }
}
