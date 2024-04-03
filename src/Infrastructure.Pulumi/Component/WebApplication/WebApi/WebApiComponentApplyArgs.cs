using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.WebApplication.WebApi
{
    public sealed class WebApiComponentInput : IComponentInput
    {
        public Namespace Namespace { get; init; } = null!;
        public string Tag { get; init; } = "";
        public ConfigFile OpenTelemetryCrd { get; init; } = null!;
    }

    public sealed class WebApiComponentOutput : IComponentOutput
    {
    }
}