namespace Tool.Make;

internal sealed class Microk8s : ConsoleAppBase
{
    public async ValueTask Start()
    {
        var target = new Targets();
        target.Add("start", static () => RunAsync("microk8s", "start"));
        await target.RunWithoutExitingAsync(["start"]);
    }
    
    public async ValueTask Stop()
    {
        var target = new Targets();
        target.Add("stop", static () => RunAsync("microk8s", "stop"));
        await target.RunWithoutExitingAsync(["stop"]);
    }
}