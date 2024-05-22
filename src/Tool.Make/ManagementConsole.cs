using Tool.Make.Constant;

namespace Tool.Make;

/// <summary>
/// Build and push management console image
/// When you run these command in out of the kubernetes cluster and using the microk8s's internal registry, you need to set insecure-registries in /var/snap/microk8s/current/args/containerd-template.toml (or ~/.docker/daemon.json)
/// </summary>
internal sealed class ManagementConsole : ConsoleAppBase
{
    private readonly Targets _target = new();
    
    [Command("build-image", "build management consle image")]
    public Task Build([Option("t")] string[]? tags = null, [Option("h")] string host = Define.ContainerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-image", () => RunAsync("docker", $"buildx build {GetBuildTags(host, tags)} -f ../../Dockerfile.ManagementConsole ../../"));

        return _target.RunWithoutExitingAsync(["build-image"]);
    }

    private string GetBuildTags(string host, string[] tags) => string.Join(" ", tags.Select(x => $"-t {host}/tool/management-console:{x}"));

    [Command("push-image", "push management console image")]
    public Task Push([Option("t")] string[]? tags = null, [Option("h")] string host = Define.ContainerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-and-push-image", () => RunAsync("docker", $"buildx build {GetBuildTags(host, tags)} -f ../../Dockerfile.ManagementConsole ../../ --push"));

        return _target.RunWithoutExitingAsync(["build-and-push-image"]);
    }

    [Command("deploy", "deploy management console")]
    public async Task Deploy(
        [Option("s")] string stack,
        [Option("t")] string? tag = "latest")
    {
        await $"pulumi config set --stack {stack} --cwd ../Infrastructure.Pulumi --path 'ManagementConsole.Tag' {tag}";
        await $"pulumi up --stack {stack} --yes --target **tool-management-console-deployment** --target-dependents --disable-integrity-checking --cwd ../Infrastructure.Pulumi";
    }
}