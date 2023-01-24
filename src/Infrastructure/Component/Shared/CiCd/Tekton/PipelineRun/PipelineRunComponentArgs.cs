using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.PipelineRun
{
    public sealed class PipelineRunComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
        public ConfigFile TektonRelease { get; set; }
    }

    public sealed class PipelineRunComponentOutput : IComponentOutput
    {
    }
}