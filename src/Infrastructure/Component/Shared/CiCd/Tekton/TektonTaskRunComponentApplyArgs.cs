using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.CiCd.Tekton
{
    public sealed class TektonTaskRunComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class TektonTaskRunComponentOutput : IComponentOutput
    {
    }
}