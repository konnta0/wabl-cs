namespace Make;

public sealed class Setup : ConsoleAppBase
{
    private readonly Targets _target;

    public Setup()
    {
        _target = new Targets();
        _target.Add("minikube-curl", static () => RunAsync("curl", "-LO https://storage.googleapis.com/minikube/releases/latest/minikube-darwin-amd64"));
        _target.Add("minikube-chmod", DependsOn("minikube-chmod"), static () => RunAsync("chmod", "+x minikube-darwin-amd64"));
        _target.Add("minikube-install", DependsOn("minikube-install"), static () => RunAsync("sudo", "install minikube-darwin-amd64 /usr/local/bin/minikube"));
        _target.Add("minikube-version", DependsOn("minikube-version"), static () => RunAsync("minikube", "version"));
        _target.Add("minikube-remove", DependsOn("minikube-remove"), static () => RunAsync("rm", "-f minikube-darwin-amd64"));

        _target.Add("pulumi-curl", static () => RunAsync("curl", "-fsSL https://get.pulumi.com | sh"));
        _target.Add("pulumi-version", DependsOn("pulumi-curl"), static () => RunAsync("pulumi", "version"));
        _target.Add("pulumi-crd2pulumi", DependsOn("pulumi-version"), static () => RunAsync("brew", "install pulumi/tap/crd2pulumi"));
    }

    [Command("minikube")]
    public Task Minikube() => _target.RunWithoutExitingAsync(["minikube-remove"]);

    [Command("pulumi")]
    public Task Pulumi() => _target.RunWithoutExitingAsync(["pulumi-crd2pulumi"]);

    [Command("all")]
    public Task All() => _target.RunWithoutExitingAsync(["minikube-remove", "pulumi-crd2pulumi"]);
}