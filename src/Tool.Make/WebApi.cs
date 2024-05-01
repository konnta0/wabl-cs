namespace Tool.Make;

/// <summary>
/// Build and push web app image
/// When you run these command in out of the kubenetes cluster and using the microk8s's internal registry, you need to set insecure-registries in /var/snap/microk8s/current/args/containerd-template.toml (or ~/.docker/daemon.json)
/// </summary>
internal sealed class WebApi : ConsoleAppBase
{
    private readonly Targets _target = new();

    private const string DockerRegistryHost = "192.168.112.5:32000";

    [Command("build-image", "build web image")]
    public Task Build([Option("t")] string[]? tags = null, [Option("h")] string host = DockerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-image", () => RunAsync("docker", $"buildx build {GetBuildTags(host, tags)} ../../"));

        return _target.RunWithoutExitingAsync(["build-image"]);
    }

    private string GetBuildTags(string host, string[] tags) => string.Join(" ", tags.Select(x => $"-t {host}/webapp/web-api:{x}"));

    [Command("push-image", "push web image")]
    public Task Push([Option("t")] string[]? tags = null, [Option("h")] string host = DockerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-and-push-image", () => RunAsync("docker", $"buildx build {GetBuildTags(host, tags)} ../../ --push"));

        return _target.RunWithoutExitingAsync(["build-and-push-image"]);
    }
    
    [Command("deploy", "deploy web app")]
    public async Task Deploy(
        [Option("s")] string stack, 
        [Option("t")] string? tag = "latest")
    {
        await $"pulumi config set --stack {stack} --cwd ../Infrastructure.Pulumi --path 'WebApplication.Tag' {tag}";
        // add '--disable-integrity-checking' https://github.com/pulumi/pulumi/issues/15959
        await $"pulumi up --stack {stack} --yes --target **web-application-web-api-deployment** --target-dependents --disable-integrity-checking --cwd ../Infrastructure.Pulumi";
    }
}