using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.TriggerBinding
{
    public sealed class TriggerBindingComponentInput : IComponentInput
    {
        public ConfigFile TektonRelease { get; set; }
        public ConfigFile TektonTrigger { get; set; }
    }

    public sealed class TriggerBindingComponentOutput : IComponentOutput
    {
    }
    
}