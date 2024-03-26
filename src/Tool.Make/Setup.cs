namespace Tool.Make;

internal sealed class Setup : ConsoleAppBase
{
    private readonly Targets _target;

    public Setup()
    {
        _target = new Targets();
        _target.Add("minikube-curl", static () => RunAsync("curl", "-LO https://storage.googleapis.com/minikube/releases/latest/minikube-darwin-amd64"));
        _target.Add("minikube-chmod", DependsOn("minikube-curl"), static () => RunAsync("chmod", "+x minikube-darwin-amd64"));
        _target.Add("minikube-install", DependsOn("minikube-chmod"), static () => RunAsync("sudo", "install minikube-darwin-amd64 /usr/local/bin/minikube"));
        _target.Add("minikube-version", DependsOn("minikube-install"), static () => RunAsync("minikube", "version"));
        _target.Add("minikube-remove", static () => RunAsync("rm", "-f minikube-darwin-amd64"));

        _target.Add("microk8s-brew-install", static () => RunAsync("brew", "install ubuntu/microk8s/microk8s"));
        _target.Add("microk8s-install", DependsOn("microk8s-brew-install"), static () => RunAsync("microk8s", "install --mem=24 --cpu=7"));
        _target.Add("microk8s-enable-plugins", DependsOn("microk8s-install"), async () =>
        {
             await "microk8s enable dashboard";
             await "microk8s enable dns";
             await "microk8s enable ingress";
             await "microk8s enable registry";
        });

        _target.Add("microk8s-notice", static () => Console.WriteLine("Please run `microk8s kubectl config view --raw >> ~/.kube/config`"));
        
        _target.Add("pulumi-curl", static () => RunAsync("curl", "-fsSL https://get.pulumi.com | sh"));
        _target.Add("pulumi-version", DependsOn("pulumi-curl"), static () => RunAsync("pulumi", "version"));
        _target.Add("pulumi-crd2pulumi", DependsOn("pulumi-version"), static () => RunAsync("brew", "install pulumi/tap/crd2pulumi"));
    }

    [Command("minikube")]
    public Task Minikube() => _target.RunWithoutExitingAsync(["minikube-remove"]);

    [Command("microk8s")]
    public async Task Microk8s()
    {
        await _target.RunWithoutExitingAsync(["microk8s-enable-plugins"]);
        await _target.RunWithoutExitingAsync(["microk8s-notice"]);
    }

    [Command("pulumi")]
    public Task Pulumi() => _target.RunWithoutExitingAsync(["pulumi-crd2pulumi"]);

    [Command("all")]
    public Task All() => _target.RunWithoutExitingAsync(["minikube-remove", "pulumi-crd2pulumi"]);
}