namespace Tool.Make;


internal class K3d
{
    private const string ClusterName = "wabl-cs";
    private const string RegistryName = "wabl-cs-registry.localhost";
    private const int RegistryPort = 58063;
    
    [Command("create")]
    public async Task CreateAsync()
    {
        var target = new Targets();
        target.Add("message", static () => Console.WriteLine("Creating k3d cluster..."));
        target.Add("create-registry", DependsOn("message"), static () => RunAsync("k3d", $"registry create {RegistryName} --port {RegistryPort}"));
        target.Add("message-add-host", DependsOn("create-registry"), static () => Console.WriteLine($"Should add the following to /etc/hosts. 127.0.0.1 k3d-{RegistryName}. see: https://k3d.io/v5.1.0/usage/registries/#preface-referencing-local-registries"));
        target.Add("create-cluster", DependsOn("create-registry"), static () => RunAsync("k3d", $"cluster create {ClusterName} --registry-use k3d-{RegistryName}:{RegistryPort} --api-port 6550 -p \"8081:80@loadbalancer\" --agents 2"));

        await target.RunWithoutExitingAsync(["create-cluster"]);
    }

    [Command("delete")]
    public async Task DeleteAsync()
    {
        var target = new Targets();
        target.Add("delete-cluster", static () => RunAsync("k3d", $"cluster delete {ClusterName}"));
        target.Add("delete-registry", static () => RunAsync("k3d", $"registry delete {RegistryName}"));

        await target.RunWithoutExitingAsync(["delete-cluster"]);
        await target.RunWithoutExitingAsync(["delete-registry"]);
    }

    [Command("start")]
    public async Task StartAsync()
    {
        var target = new Targets();
        target.Add("start", static () => RunAsync("k3d", $"cluster start {ClusterName}"));

        await target.RunWithoutExitingAsync(["start"]);
    }
    
    [Command("stop")]
    public async Task StopAsync()
    {
        var target = new Targets();
        target.Add("stop", static () => RunAsync("k3d", $"cluster stop {ClusterName}"));

        await target.RunWithoutExitingAsync(["stop"]);
    }
}