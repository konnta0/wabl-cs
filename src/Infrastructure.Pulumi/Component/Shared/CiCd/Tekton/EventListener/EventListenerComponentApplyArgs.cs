using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.EventListener
{
    public sealed class EventListenerComponentInput : IComponentInput
    {
        public Namespace Namespace { get; init; } = null!;
        public ConfigFile TektonRelease { get; init; } = null!;
        public ConfigFile TektonTrigger { get; init; } = null!;
        public ConfigFile TektonInterceptor { get; init; } = null!;
    }

    public sealed class EventListenerComponentOutput : IComponentOutput
    {
    }
    
}