using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Tekton
{
    public sealed class TektonComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; set; }
    }

    public sealed class TektonComponentOutput : IComponentOutput
    {
    }
}