using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.CiCd.Tekton.Pipeline
{
    public sealed class PipelineComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class PipelineComponentOutput : IComponentOutput
    {
    }
}