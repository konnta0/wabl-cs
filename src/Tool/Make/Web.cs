
namespace Make;

public sealed class Web : ConsoleAppBase
{
    private readonly Targets _target;

    public Web()
    {
        _target = new Targets();
        _target.Add("build", () => RunAsync("docker", "build -t core.harbor.cr.test/webapp/web-api:latest ../../../"));
        _target.Add("push", DependsOn("build"), () => RunAsync("docker", "push core.harbor.cr.test/webapp/web-api:latest"));
    }

    [Command("build", "build web")]
    public Task Build() =>_target.RunWithoutExitingAsync(new[] { "build" });

    [Command("push", "push web")]
    public Task Push() => _target.RunWithoutExitingAsync(new[] { "push" });
}