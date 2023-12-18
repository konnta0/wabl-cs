using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.PipelineRun
{
    public sealed class PipelineRunComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
        public ConfigFile TektonRelease { get; set; } = null!;
        public bool Deploy { get; set; }
    }

    public sealed class PipelineRunComponentOutput : IComponentOutput
    {
    }
}