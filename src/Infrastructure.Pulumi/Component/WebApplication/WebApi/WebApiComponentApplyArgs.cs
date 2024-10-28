using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.WebApplication.WebApi
{
    public sealed class WebApiComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
        public required string CanaryTag { get; init; }
        public required string Tag { get; init; }
        public required ConfigFile OpenTelemetryCrd { get; init; }
    }

    public sealed class WebApiComponentOutput : IComponentOutput
    {
    }
}