namespace Tool.Make;

/// <summary>
/// Build and push web app image
/// When you run these command in out of the kubenetes cluster and using the microk8s's internal registry, you need to set insecure-registries in /var/snap/microk8s/current/args/containerd-template.toml (or ~/.docker/daemon.json)
/// </summary>
public sealed class WebApp : ConsoleAppBase
{
    private readonly Targets _target;

    private const string DockerRegistryHost = "192.168.105.27:32000";
    
    public WebApp()
    {
        _target = new Targets();
    }

    [Command("build-image", "build web image")]
    public Task Build([Option("t")] string[]? tags = null, [Option("h")] string host = DockerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-image", () => RunAsync("docker", $"build {GetBuildTags(host, tags)} ../../../"));

        return _target.RunWithoutExitingAsync(["build"]);
    }

    private string GetBuildTags(string host, string[] tags) => string.Join(" ", tags.Select(x => $"-t {host}/webapp/web-api:{x}"));

    [Command("push-image", "push web image")]
    public Task Push([Option("t")] string[]? tags = null, [Option("h")] string host = DockerRegistryHost)
    {
        tags ??= ["latest"];
        _target.Add("build-image", () => RunAsync("docker", $"build {GetBuildTags(host, tags)} ../../../"));
        _target.Add("push-image", DependsOn("build"),
            () => RunAsync("docker", $"push -a {DockerRegistryHost}/webapp/web-api"));

        return _target.RunWithoutExitingAsync(["push"]);
    }
    
    [Command("deploy", "deploy web app")]
    public async Task Deploy(
        [Option("s")] string stack, 
        [Option("t")] string? tag = "latest")
    {
        await $"pulumi config set --stack {stack} --path 'WebApplication.Tag' {tag}";
        await $"pulumi up --stack {stack} --yes --target **web-application-web-api-deployment** --cwd ../../Tool.Infrastructure.Pulumi";
    }
}