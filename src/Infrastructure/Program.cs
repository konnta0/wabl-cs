using System.Threading.Tasks;
using Infrastructure.CI_CD.Extension;
using Infrastructure.Extension;
using Infrastructure.Stack;
using Infrastructure.VersionControlSystem.Extension;
using Infrastructure.WebApplication.Extension;
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
        serviceCollection.AddScoped<DevelopmentStack>();
    }
}
