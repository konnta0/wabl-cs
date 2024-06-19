using ConsoleAppFramework;
using Tool.Make.Constant;

namespace Tool.Make;

/// <summary>
/// Build and push web app image
/// When you run these command in out of the kubenetes cluster and using the microk8s's internal registry, you need to set insecure-registries in /var/snap/microk8s/current/args/containerd-template.toml (or ~/.docker/daemon.json)
/// </summary>
internal sealed class WebApi
{
    private readonly Targets _target = new();

    /// <summary>
    /// build web app image
    /// </summary>
    /// <param name="tags">-t, tags</param>
    /// <param name="host">-h, host</param>
    /// <returns></returns>
    [Command("build-image")]
    public Task Build(string[]? tags = null, string host = Define.ContainerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-image", () => RunAsync("docker", $"buildx build {GetBuildTags(host, tags)} ../../"));

        return _target.RunWithoutExitingAsync(["build-image"]);
    }

    private string GetBuildTags(string host, string[] tags) => string.Join(" ", tags.Select(x => $"-t {host}/webapp/web-api:{x}"));

    /// <summary>
    /// push web image
    /// </summary>
    /// <param name="tags">-t, tags</param>
    /// <param name="host">-h, host</param>
    /// <returns></returns>
    [Command("push-image")]
    public Task Push(string[]? tags = null, string host = Define.ContainerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-and-push-image", () => RunAsync("docker", $"buildx build {GetBuildTags(host, tags)} ../../ --push"));

        return _target.RunWithoutExitingAsync(["build-and-push-image"]);
    }

    /// <summary>
    /// deploy web app
    /// </summary>
    /// <param name="stack">-s, stack</param>
    /// <param name="tag">-t, tag</param>
    [Command("deploy")]
    public async Task Deploy(string stack, string? tag = "latest")
    {
        await $"pulumi config set --stack {stack} --cwd ../Infrastructure.Pulumi --path 'WebApplication.Tag' {tag}";
        // add '--disable-integrity-checking' https://github.com/pulumi/pulumi/issues/15959
        await $"pulumi up -s {stack} --yes --target **web-application-web-api-deployment** --target-dependents --disable-integrity-checking --cwd ../Infrastructure.Pulumi";
    }
}