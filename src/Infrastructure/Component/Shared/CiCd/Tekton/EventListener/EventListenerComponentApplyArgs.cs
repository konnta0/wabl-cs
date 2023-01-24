using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.EventListener
{
    public sealed class EventListenerComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
        public ConfigFile TektonRelease { get; set; }
        public ConfigFile TektonTrigger { get; set; }
    }

    public sealed class EventListenerComponentOutput : IComponentOutput
    {
    }
    
}