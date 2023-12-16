namespace Make;

public sealed class CDKTF : ConsoleAppBase
{
    private readonly Targets _target;

    public CDKTF()
    {
        _target = new Targets();
        _target.Add("install-node", () => RunAsync("brew", "install node"));
        _target.Add("install", DependsOn("install-node"), () => RunAsync("npm", "install -g cdktf-cli"));
    }


    [Command("install", "install cdktf")]
    public Task Install() => _target.RunWithoutExitingAsync(["install"]);
}