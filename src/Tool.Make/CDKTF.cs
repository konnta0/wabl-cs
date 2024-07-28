using ConsoleAppFramework;

namespace Tool.Make;

internal sealed class CDKTF
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

    /// <summary>
    /// "install cdktf"
    /// </summary>
    /// <returns></returns>
    [Command("install")]
    public Task Install() => _target.RunWithoutExitingAsync(["install"]);

    /// <summary>
    /// Synthesize Terraform resources
    /// </summary>
    /// <returns></returns>
    [Command("synth")]
    public async Task Synthesize()
    {
        await "cd ../Infrastructure.CDKTF; cdktf synth --hcl";
    }

    /// <summary>
    /// Synthesize Terraform resources
    /// </summary>
    /// <param name="stack"></param>
    [Command("diff")]
    public async Task Diff(string stack)
    {
        await $"cd ../Infrastructure.CDKTF; cdktf diff {stack}";
    }

    /// <summary>
    /// Deploy specified stacks using CDKTF
    /// </summary>
    /// <param name="stacks">An array of stack names to deploy</param>
    [Command("deploy")]
    public async Task Deploy(string[] stacks)
    {
        var s = string.Join(' ', stacks);
        await $"cd ../Infrastructure.CDKTF; cdktf deploy {s}";
    }

    /// <summary>
    /// Destroy specified stacks using CDKTF
    /// </summary>
    /// <param name="stacks">An array of stack names to destroy</param>
    [Command("destroy")]
    public async Task Destroy(string[] stacks)
    {
        var s = string.Join(' ', stacks);
        await $"cd ../Infrastructure.CDKTF; cdktf destroy {s}";
    }
}