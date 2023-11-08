namespace Make;

internal sealed class Minikube : ConsoleAppBase
{
    public async ValueTask Start()
    {
        const string memory = "16g";
        const string cpu = "7";
        const string driver = "docker";
        const string containerRuntime = "containerd";
        const string diskSize = "200gb";
        const string nodes = "1";
        const string insecureRegistry = "core.harbor.cr.test";
        const string kubernetesVersion = "v1.24.6";
        var target = new Targets();
        target.Add("start", static () => RunAsync("minikube",
        $"start --memory={memory} --cpus={cpu} --driver={driver} --container-runtime={containerRuntime} --disk-size={diskSize} --nodes={nodes} --insecure-registry=\"{insecureRegistry}\" --kubernetes-version {kubernetesVersion}"));
        target.Add("ingress", static () => RunAsync("minikube", "addons enable ingress"));
        target.Add("ingress-dns", static () => RunAsync("minikube", "addons enable ingress-dns"));
        target.Add("metrics-server", static () => RunAsync("minikube", "addons enable metrics-server"));
        
        await target.RunWithoutExitingAsync(new[] { "start" });
        await target.RunWithoutExitingAsync(new[] { "ingress" });
        await target.RunWithoutExitingAsync(new[] { "ingress-dns" });
        await target.RunWithoutExitingAsync(new[] { "metrics-server" });
    }

    public async ValueTask Stop()
    {
        var target = new Targets();
        target.Add("stop", static () => RunAsync("minikube", "stop"));
        await target.RunWithoutExitingAsync(new[] { "stop" });
    }

    public async ValueTask Pause()
    {
        var target = new Targets();
        target.Add("pause", static () => RunAsync("minikube", "pause"));
        await target.RunWithoutExitingAsync(new[] { "pause" });
    }
}