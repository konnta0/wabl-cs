using System.Threading.Tasks;
using Infrastructure.CI_CD.Tekton;
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
        serviceCollection.AddScoped<Tekton>();
        serviceCollection.AddScoped<DevelopmentStack>();
    }
}
