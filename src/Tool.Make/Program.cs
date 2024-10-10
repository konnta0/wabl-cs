using Tool.Make;

var app = ConsoleApp.Create();
app.Add<CDKTF>("cdktf");
app.Add<Cert>("cert");
app.Add<K3d>("k3d");
app.Add<ManagementConsole>("management-console");
app.Add<Microk8s>("microk8s");
app.Add<Migration>("migration");
app.Add<Minikube>("minikube");
app.Add<Pulsar>("pulsar");
app.Add<Pulumi>("pulumi");
app.Add<Setup>("setup");
app.Add<WebApi>("webapi");
app.Add("example", () =>
{
    var target = new Targets();
    Tool.Make.Common.DirectoryUtil.TryGetSolutionDirectoryInfo(out var directory);
    target.Add("test", async () => await $"echo {directory.FullName}");

    return target.RunWithoutExitingAsync(["test"]);
});
await app.RunAsync(args);
