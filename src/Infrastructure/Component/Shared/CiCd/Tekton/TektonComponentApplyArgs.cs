using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.CiCd.Tekton
{
    public sealed class TektonComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class TektonComponentOutput : IComponentOutput
    {
    }
}