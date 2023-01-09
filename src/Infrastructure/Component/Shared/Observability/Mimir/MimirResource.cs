using Infrastructure.Component.Shared.Observability.Loki;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Component.Shared.Observability.Mimir
{
    public class MimirResource
    {
        private readonly ILogger<LokiResource> _logger;
        private readonly Config _config;

        public MimirResource(ILogger<LokiResource> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public void Apply()
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
                                ["endpoint"] = "minio:9000",
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
                                ["endpoint"] = "minio:9000",
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
            
            var mimir = new Release("mimir-distributed", new ReleaseArgs
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
                CreateNamespace = true,
                Namespace = _config.GetObservabilityConfig().Namespace
            });
        }
    }
}