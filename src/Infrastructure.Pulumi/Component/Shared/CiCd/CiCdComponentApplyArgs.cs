using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.CiCd
{
    public sealed class CiCdComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
    }

    public sealed class CiCdComponentOutput : IComponentOutput
    {
    }
}