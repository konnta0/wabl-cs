using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.CiCd
{
    public sealed class CiCdComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class CiCdComponentOutput : IComponentOutput
    {
    }
}