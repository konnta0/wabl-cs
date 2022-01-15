using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using NBomber.Plugins.Network.Ping;

namespace LoadTestConsoleApp.Scenario;

[Command("run")]
public partial class ScenarioRunner : ConsoleAppBase, IDisposable
{
    private IClientFactory<HttpClient>? _httpFactory;

    public ScenarioRunner()
    {
        _httpFactory = HttpClientFactory.Create();

    }
    
    private void RunInternal(string scenarioName, params IStep[] steps)
    {
        var scenario = ScenarioBuilder
            .CreateScenario(scenarioName, steps)
            .WithWarmUpDuration(TimeSpan.FromSeconds(5))
            .WithLoadSimulations(Simulation.InjectPerSec(rate: 100, during: TimeSpan.FromSeconds(30)));

        var pingPluginConfig = PingPluginConfig.CreateDefault("nbomber.com");
        var pingPlugin = new PingPlugin(pingPluginConfig);

        NBomberRunner
            .RegisterScenarios(scenario)
            .WithWorkerPlugins(pingPlugin)
            .Run();
    }

    public void Dispose()
    {
    }
}