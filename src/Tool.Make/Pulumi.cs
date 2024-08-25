namespace Tool.Make;

public sealed class Pulumi
{
    private const string InfrastructureDir = "../Infrastructure.Pulumi";

    /// <summary>
    /// up
    /// </summary>
    /// <param name="stack"></param>
    /// <returns></returns>
    [Command("up")]
    public Task Up(string stack = "local")
    {
        var target = new Targets();
        target.Add("up", () => RunAsync("pulumi", $"up --cwd {InfrastructureDir} -v=6 -s {stack}"));
        return target.RunWithoutExitingAsync(["up"]);
    }

    /// <summary>
    /// destroy infrastructure
    /// </summary>
    /// <param name="stack"></param>
    /// <returns></returns>
    [Command("destroy")]
    public Task Destroy(string stack = "local")
    {
        var target = new Targets();
        target.Add("destroy", () => RunAsync("pulumi", $"destroy --cwd {InfrastructureDir} -s {stack}"));
        return target.RunWithoutExitingAsync(["destroy"]);
    }

    /// <summary>
    /// show urns
    /// </summary>
    /// <param name="stack"></param>
    /// <returns></returns>
    [Command("urns")]
    public Task Urns(string stack = "local")
    {
        var target = new Targets();
        target.Add("urns", () => RunAsync("pulumi", $"stack --show-urns --cwd {InfrastructureDir} -s {stack}"));
        return target.RunWithoutExitingAsync(["urns"]);
    }

    /// <summary>
    /// pulumi delete. (e.g.) urn is 'urn:pulumi:develop::Infrastructure.Pulumi::kubernetes:helm.sh/v3:Release::cert-manager'
    /// </summary>
    /// <param name="urn">delete urn</param>
    /// <param name="stack">stack</param>
    /// <returns></returns>
    [Command("delete")]
    public Task Delete(string urn, string stack = "local")
    {
        var target = new Targets();
        target.Add("delete", () => RunAsync("pulumi", $"state delete {urn} --cwd {InfrastructureDir} -s {stack}"));
        return target.RunWithoutExitingAsync(["delete"]);
    }

    [Command("output")]
    public Task Output(string stack = "local")
    {
        var target = new Targets();
        target.Add("output", () => RunAsync("pulumi", $"output --cwd {InfrastructureDir} -s {stack}"));
        return target.RunWithoutExitingAsync(["output"]);
    }

    [Command("refresh")]
    public Task Refresh(string stack = "local")
    {
        var target = new Targets();
        target.Add("refresh", () => RunAsync("pulumi", $"refresh --cwd {InfrastructureDir} -s {stack}"));
        return target.RunWithoutExitingAsync(["refresh"]);
    }
}