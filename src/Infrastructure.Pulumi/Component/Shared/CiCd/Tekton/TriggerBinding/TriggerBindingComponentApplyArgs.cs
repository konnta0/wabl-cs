using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.TriggerBinding
{
    public sealed class TriggerBindingComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; set; }
        public required ConfigFile TektonRelease { get; set; }
        public required ConfigFile TektonTrigger { get; set; }
    }

    public sealed class TriggerBindingComponentOutput : IComponentOutput
    {
    }
    
}