using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Spinnaker
{
    public sealed class SpinnakerComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class SpinnakerComponentOutput : IComponentOutput
    {
    }
}