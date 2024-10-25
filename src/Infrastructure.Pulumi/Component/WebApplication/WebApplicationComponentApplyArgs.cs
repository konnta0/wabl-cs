using Infrastructure.Pulumi.Component.Shared.Certificate;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.WebApplication
{
    public sealed class WebApplicationComponentInput : IComponentInput
    {
        public ConfigFile OpenTelemetryCrd { get; set; } = null!;
        public required CertificateComponentOutput CertificateComponentOutput { get; init; }
    }

    public sealed class WebApplicationComponentOutput : IComponentOutput
    {
    }
}