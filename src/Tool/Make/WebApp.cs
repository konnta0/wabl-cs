namespace Make;

public sealed class WebApp : ConsoleAppBase
{
    private readonly Targets _target;

    public WebApp()
    {
        _target = new Targets();
    }

    [Command("build-image", "build web image")]
    public Task Build([Option("t")] string[]? tags = null)
    {
        tags ??= ["latest"];
        _target.Add("build-image", () => RunAsync("docker", $"build {GetBuildTags(tags)} ../../../"));

        return _target.RunWithoutExitingAsync(["build"]);
    }

    private string GetBuildTags(string[] tags) => string.Join(" ", tags.Select(static x => $"-t core.harbor.cr.test/webapp/web-api:{x}"));
    
    [Command("push-image", "push web image")]
    public Task Push([Option("t")] string[]? tags = null)
    {
        tags ??= ["latest"];
        _target.Add("build-image", () => RunAsync("docker", $"build {GetBuildTags(tags)} ../../../"));
        _target.Add("push-image", DependsOn("build"),
            () => RunAsync("docker", "push -a core.harbor.cr.test/webapp/web-api"));

        return _target.RunWithoutExitingAsync(["push"]);
    }
}