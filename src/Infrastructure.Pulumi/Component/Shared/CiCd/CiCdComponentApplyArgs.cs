using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.CiCd
{
    public sealed class CiCdComponentInput : IComponentInput
    {
        public Namespace Namespace { get; init; } = null!;
    }

    public sealed class CiCdComponentOutput : IComponentOutput
    {
    }
}