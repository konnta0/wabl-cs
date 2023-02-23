using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.Pipeline
{
    public sealed class PipelineComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
        public ConfigFile TektonRelease { get; set; } = null!;
    }

    public sealed class PipelineComponentOutput : IComponentOutput
    {
    }
}