namespace Tool.Make;

internal sealed class Microk8s : ConsoleAppBase
{
    public async ValueTask Stop()
    {
        var target = new Targets();
        target.Add("stop", static () => RunAsync("microk8s", "stop"));
        await target.RunWithoutExitingAsync(["stop"]);
    }
}