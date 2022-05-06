using System.Threading.Tasks;
using Infrastructure.Extension;
using Infrastructure.Stack;
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
        serviceCollection.AddResource();
        serviceCollection.AddObservability();
        serviceCollection.AddScoped<DevelopmentStack>();
    }
}
