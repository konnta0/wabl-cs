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
        Step.Create("fetch_html_page",
            _httpFactory,
            async context =>
            {
                var response = await context.Client.GetAsync("https://nbomber.com", context.CancellationToken);

                return response.IsSuccessStatusCode
                    ? Response.Ok(statusCode: (int)response.StatusCode)
                    : Response.Fail(statusCode: (int)response.StatusCode);
            });
}