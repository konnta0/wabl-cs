using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.WebApplication.WebApi
{
    public sealed class WebApiComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
        public ConfigFile OpenTelemetryCrd { get; set; } = null!;
    }

    public sealed class WebApiComponentOutput : IComponentOutput
    {
    }
}