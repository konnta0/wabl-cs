using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.TriggerTemplate
{
    public sealed class TriggerTemplateComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
        public ConfigFile TektonRelease { get; set; } = null!;
        public ConfigFile TektonTrigger { get; set; } = null!;
    }

    public sealed class TriggerTemplateComponentOutput : IComponentOutput
    {
    }
    
}