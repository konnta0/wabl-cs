using Infrastructure.Pulumi.Extension;
using Infrastructure.Pulumi.Component.Shared.Observability.Loki;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Mimir
{
    public class MimirComponent : IComponent<MimirComponentInput, MimirComponentOutput>
    {
        private readonly ILogger<LokiComponent> _logger;
        private readonly Config _config;

        public MimirComponent(ILogger<LokiComponent> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }
        
        public MimirComponentOutput Apply(MimirComponentInput input)
        {
            // https://github.com/grafana/mimir/blob/mimir-distributed-3.1.0/operations/helm/charts/mimir-distributed/values.yaml
            var values = new InputMap<object>
            {
                ["minio"] = new InputMap<object>
                {
                    ["enabled"] = false
                },
                ["mimir"] = new InputMap<object>
                {
                    ["structuredConfig"] = new InputMap<object>
                    {
                        ["alertmanager_storage"] = new InputMap<object>
                        {
                            ["backend"] = "s3",
                            ["s3"] = new InputMap<object>
                            {
                                ["access_key_id"] = "mimir",
                                ["bucket_name"] = "mimir-ruler", 
                                ["endpoint"] = "shared-minio:9000",
                                ["insecure"] = true,
                                ["secret_access_key"] = "mimirsecret" 
                            }
                        },
                        ["blocks_storage"] = new InputMap<object>
                        {
                            ["s3"] = new InputMap<object>
                            {
                                ["access_key_id"] = "mimir",
                                ["bucket_name"] = "mimir-tsdb",
                                ["endpoint"] = "shared-minio:9000",
                                ["insecure"] = true,
                                ["secret_access_key"] = "mimirsecret"
                            }
                        }
                    }
                },
                ["ingester"] = new InputMap<object>
                {
                    ["replicas"] = 2
                } 
            };
            
            var mimir = new Release("mimir", new ReleaseArgs
            {
                Name = "mimir-distributed",
                Chart = "mimir-distributed",
                // helm search repo grafana/mimir-distributed --versions | head -n 5
                Version = "3.1.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                
                Values = values,
                Atomic = true,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            });
            return new MimirComponentOutput();
        }
    }
}