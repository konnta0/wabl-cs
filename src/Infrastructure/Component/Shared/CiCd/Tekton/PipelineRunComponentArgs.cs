using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.CiCd.Tekton
{
    public sealed class PipelineRunComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class PipelineRunComponentOutput : IComponentOutput
    {
    }
}