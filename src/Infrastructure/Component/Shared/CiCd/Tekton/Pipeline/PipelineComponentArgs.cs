using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.Pipeline
{
    public sealed class PipelineComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
        public ConfigFile TektonRelease { get; set; }
    }

    public sealed class PipelineComponentOutput : IComponentOutput
    {
    }
}