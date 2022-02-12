using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using NBomber.Plugins.Network.Ping;

namespace LoadTestConsoleApp.Scenario;

[Command("run")]
public partial class ScenarioRunner : ConsoleAppBase, IDisposable
{
    private readonly IClientFactory<HttpClient>? _httpFactory;

    public ScenarioRunner()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.Timeout = new TimeSpan(0, 0, 3);

        _httpFactory = HttpClientFactory.Create("http_factory", client);
    }
    
    private void RunInternal(string scenarioName, params IStep[] steps)
    {
        var scenario = ScenarioBuilder
            .CreateScenario(scenarioName, steps)
            .WithWarmUpDuration(TimeSpan.FromSeconds(5))
            .WithLoadSimulations(Simulation.InjectPerSec(rate: 1, during: TimeSpan.FromSeconds(30)));

        // var pingPluginConfig = PingPluginConfig.CreateDefault("http://localhost:8080/api/health-check/ping");
        // var pingPlugin = new PingPlugin(pingPluginConfig);

        NBomberRunner
            .RegisterScenarios(scenario)
//            .WithWorkerPlugins(pingPlugin)
            .Run();
    }

    public void Dispose()
    {
    }
}