using ConsoleAppFramework;
using Tool.Make.Constant;

namespace Tool.Make;

/// <summary>
/// Build and push management console image
/// When you run these command in out of the kubernetes cluster and using the microk8s's internal registry, you need to set insecure-registries in /var/snap/microk8s/current/args/containerd-template.toml (or ~/.docker/daemon.json)
/// </summary>
internal sealed class ManagementConsole
{
    private readonly Targets _target = new();
    
    /// <summary>
    /// build management console image
    /// </summary>
    /// <param name="tags">-t, tags</param>
    /// <param name="host">-h, host</param>
    /// <returns></returns>
    [Command("build-image")]
    public Task Build(string[]? tags = null, string host = Define.ContainerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-image", () => RunAsync("docker", $"buildx build {GetBuildTags(host, tags)} -f ../../Dockerfile.ManagementConsole ../../"));

        return _target.RunWithoutExitingAsync(["build-image"]);
    }

    private string GetBuildTags(string host, string[] tags) => string.Join(" ", tags.Select(x => $"-t {host}/tool/management-console:{x}"));

    /// <summary>
    /// push management console image
    /// </summary>
    /// <param name="tags">-t, tags</param>
    /// <param name="host">-h, host</param>
    /// <returns></returns>
    [Command("push-image")]
    public Task Push(string[]? tags = null, string host = Define.ContainerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-and-push-image", () => RunAsync("docker", $"buildx build {GetBuildTags(host, tags)} -f ../../Dockerfile.ManagementConsole ../../ --push"));

        return _target.RunWithoutExitingAsync(["build-and-push-image"]);
    }

    /// <summary>
    /// deploy management console
    /// </summary>
    /// <param name="stack">-s, stack</param>
    /// <param name="tag">-t, tag</param>
    [Command("deploy")]
    public async Task Deploy(string stack, string? tag = "latest")
    {
        await $"pulumi config set --stack {stack} --cwd ../Infrastructure.Pulumi --path 'ManagementConsole.Tag' {tag}";
        await $"pulumi up -s {stack} --yes --target **tool-management-console-deployment** --target-dependents --disable-integrity-checking --cwd ../Infrastructure.Pulumi";
    }

    /// <summary>
    /// tilt
    /// </summary>
    /// <param name="down">-d, down</param>
    /// <param name="up">-u, up</param>
    [Command("tilt")]
    public async Task Tilt(bool down, bool up)
    {
        if (down)
        {
            await "tilt down -f ../ManagementConsole.Presentation/Tiltfile";
        }

        if (up)
        {
            await "tilt up -f ../ManagementConsole.Presentation/Tiltfile";
        }
    }
}