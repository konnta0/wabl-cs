using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.EventListener
{
    public sealed class EventListenerComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
        public required ConfigFile TektonRelease { get; init; }
        public required ConfigFile TektonTrigger { get; init; }
        public required ConfigFile TektonInterceptor { get; init; }
    }

    public sealed class EventListenerComponentOutput : IComponentOutput
    {
    }
    
}