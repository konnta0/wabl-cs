using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.TriggerTemplate
{
    public sealed class TriggerTemplateComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
        public ConfigFile TektonRelease { get; set; }
        public ConfigFile TektonTrigger { get; set; }
    }

    public sealed class TriggerTemplateComponentOutput : IComponentOutput
    {
    }
    
}