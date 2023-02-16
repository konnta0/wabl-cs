using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.WebApplication.Dotnet
{
    public sealed class DotnetApplicationComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
        public ConfigFile OpenTelemetryCrd { get; set; } = null!;
    }

    public sealed class DotnetApplicationComponentOutput : IComponentOutput
    {
    }
}