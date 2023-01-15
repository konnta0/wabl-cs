using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.CiCd.Tekton.Task
{
    public sealed class TektonTaskComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class TektonTaskComponentOutput : IComponentOutput
    {
    }
}