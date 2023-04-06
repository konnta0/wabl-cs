using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared
{
    public class SharedComponent : IComponent<SharedComponentInput, SharedComponentOutput>
    {
        public SharedComponentOutput Apply(SharedComponentInput input)
        {
            return new SharedComponentOutput();
        }
    }
}