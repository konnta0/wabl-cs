using ConsoleAppFramework;

namespace Tool.Make;

internal sealed class Cert
{
    private const string Domain = "cr.test";
    private const string CertificatePath = "ca.crt";
    private const string SecretNamespace = "shared";
    private const string SecretName = "harbor-certificate";
    private const string CertificateName = "ca.crt";

    [Command("add-docker")]
    public async Task AddDocker()
    {
        // see https://matsuand.github.io/docs.docker.jp.onthefly/desktop/mac/#directory-structures-for-certificates
        var target = new Targets();
        target.Add("create-directory", static () => RunAsync("sudo", $"mkdir -p /etc/docker/certs.d/{Domain}/"));
        target.Add("cp", DependsOn("create-directory"),
            static () => RunAsync("sudo", $"cp -f {CertificatePath} /etc/docker/certs.d/{Domain}/"));
        target.Add("echo", DependsOn("cp"), static () => RunAsync("echo", "please docker restart!!!!"));
        await target.RunWithoutExitingAsync(["echo"]);
    }

    [Command("get")]
    public async Task Get()
    {
        var target = new Targets();
        target.Add("sudo",
            static () => RunAsync("sudo",
                $"kubectl get secrets {SecretName} -n {SecretNamespace} -o jsonpath='{{.data.tls\\.crt}}' | base64 -D > {CertificateName})"));
        await target.RunWithoutExitingAsync(["sudo"]);
    }

    [Command("add")]
    public async Task Add()
    {
        var target = new Targets();
        target.Add("sudo",
            static () => RunAsync("sudo",
                $"security add-trusted-cert -d -r trustAsRoot -p ssl -k /Library/Keychains/System.keychain {CertificateName}"));
        await target.RunWithoutExitingAsync(["sudo"]);
    }
}