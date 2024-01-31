namespace Tool.Make;

public sealed class CDKTF : ConsoleAppBase
{
    private readonly Targets _target;

    public CDKTF()
    {
        _target = new Targets();
        _target.Add("tap-terraform", () => RunAsync("brew", "tap hashicorp/tap"));
        _target.Add("install-terraform", DependsOn("tap-terraform"), () => RunAsync("brew", "install hashicorp/tap/terraform"));
        _target.Add("install-node", DependsOn("install-terraform"),  () => RunAsync("brew", "install node"));
        _target.Add("install", DependsOn("install-node"), () => RunAsync("npm", "install -g cdktf-cli"));
    }


    [Command("install", "install cdktf")]
    public Task Install() => _target.RunWithoutExitingAsync(["install"]);
}