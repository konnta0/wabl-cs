namespace Make;

public sealed class Pulumi : ConsoleAppBase
{
    private const string InfrastructureDir = "../../Infrastructure";

    [Command("up", "up")]
    public Task Up([Option("stack")] string stack = "local")
    {
        var target = new Targets();
        target.Add("up", () => RunAsync("pulumi", $"up --cwd {InfrastructureDir} -v=6 --stack {stack}"));
        return target.RunWithoutExitingAsync(["up"]);
    }

    [Command("destroy", "destroy infrastructure")]
    public Task Destroy([Option("stack")] string stack = "local")
    {
        var target = new Targets();
        target.Add("destroy", () => RunAsync("pulumi", $"destroy --cwd {InfrastructureDir} --stack {stack}"));
        return target.RunWithoutExitingAsync(["destroy"]);
    }

    [Command("urns", "show urns")]
    public Task Urns([Option("stack")] string stack = "local")
    {
        var target = new Targets();
        target.Add("urns", () => RunAsync("pulumi", $"stack --show-urns --cwd {InfrastructureDir} --stack {stack}"));
        return target.RunWithoutExitingAsync(["urns"]);
    }

    [Command("delete",
        "pulumi delete. (e.g.) urn is 'urn:pulumi:develop::Infrastructure::kubernetes:helm.sh/v3:Release::cert-manager'")]
    public Task Delete([Option("urn", "delete urn")] string urn, [Option("stack")] string stack = "local")
    {
        var target = new Targets();
        target.Add("delete", () => RunAsync("pulumi", $"state delete {urn} --cwd {InfrastructureDir} --stack {stack}"));
        return target.RunWithoutExitingAsync(["delete"]);
    }

    [Command("output")]
    public Task Output([Option("stack")] string stack = "local")
    {
        var target = new Targets();
        target.Add("output", () => RunAsync("pulumi", $"output --cwd {InfrastructureDir} --stack {stack}"));
        return target.RunWithoutExitingAsync(["output"]);
    }
}