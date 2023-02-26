using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Component.Shared.Storage.Redis
{
    public class RedisComponent : IComponent<RedisComponentInput, RedisComponentOutput>
    {
        public RedisComponentOutput Apply(RedisComponentInput input)
        {
            var values = new InputMap<object>
            {

            };
            _ = new Release("redis-ha", new ReleaseArgs
            {
                Name = "redis-ha",
                Chart = "redis-ha",
                //  helm search repo grafana/grafana --versions | head -n 5
                Version = "4.22.4",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://dandydeveloper.github.io/charts"
                },
                Atomic = true,
                Values = values,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            });
            return new RedisComponentOutput();
        }
    }
}