using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.TriggerBinding
{
    public sealed class TriggerBindingComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
        public ConfigFile TektonRelease { get; set; } = null!;
        public ConfigFile TektonTrigger { get; set; } = null!;
    }

    public sealed class TriggerBindingComponentOutput : IComponentOutput
    {
    }
    
}