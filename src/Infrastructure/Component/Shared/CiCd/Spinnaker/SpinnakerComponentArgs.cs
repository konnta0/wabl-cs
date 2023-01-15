using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.CiCd.Spinnaker
{
    public sealed class SpinnakerComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class SpinnakerComponentOutput : IComponentOutput
    {
    }
}