using NBomber.Contracts;
using NBomber.CSharp;

namespace LoadTestConsoleApp.Scenario;

public partial class ScenarioRunner
{
    [Command("list")]
    public void ListScenario()
    {
        RunInternal(nameof(ListScenario), ListScenarioStep001);
    }

    private IStep ListScenarioStep001 =>
        Step.Create("001",
            _httpFactory,
            async context =>
            {
                var response = await context.Client.GetAsync("http://localhost:8080/api/health-check/ping", context.CancellationToken);

                return response.IsSuccessStatusCode
                    ? Response.Ok(statusCode: (int)response.StatusCode)
                    : Response.Fail(statusCode: (int)response.StatusCode);
            });
}