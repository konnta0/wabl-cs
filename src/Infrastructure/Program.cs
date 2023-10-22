using System.Threading.Tasks;
using Infrastructure.Component.Shared.Extension;
using Infrastructure.Component.Tool.Extension;
using Infrastructure.Component.WebApplication.Extension;
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
