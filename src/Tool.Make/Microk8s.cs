namespace Tool.Make;

internal sealed class Microk8s
{
    [Command("start")]
    public async Task StartAsync()
    {
        var target = new Targets();
        target.Add("start", static () => RunAsync("microk8s", "start"));
        await target.RunWithoutExitingAsync(["start"]);
    }

    [Command("stop")]
    public async Task Stop()
    {
        var target = new Targets();
        target.Add("stop", static () => RunAsync("microk8s", "stop"));
        await target.RunWithoutExitingAsync(["stop"]);
    }
}