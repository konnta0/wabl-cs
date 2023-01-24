using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.TriggerBinding
{
    public sealed class TriggerBindingComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
        public ConfigFile TektonRelease { get; set; }
        public ConfigFile TektonTrigger { get; set; }
    }

    public sealed class TriggerBindingComponentOutput : IComponentOutput
    {
    }
    
}