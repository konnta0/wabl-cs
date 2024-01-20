using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Config = Pulumi.Config;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Tempo
{
    public class TempoComponent : IComponent<TempoComponentInput, TempoComponentOutput>
    {
        private readonly ILogger<TempoComponent> _logger;
        private readonly Config _config;

        public TempoComponent(ILogger<TempoComponent> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }
        
        public TempoComponentOutput Apply(TempoComponentInput input)
        {
            // https://github.com/grafana/helm-charts/blob/main/charts/tempo-distributed/values.yaml
            var values = new Dictionary<string, object>
            {
                ["enterprise"] = new InputMap<object>
                {
                    ["enabled"] = false
                },
                ["search"] = new Dictionary<string, object>
                {
                    ["enabled"] = true
                },
                ["traces"] = new Dictionary<string, object>
                {
                    ["otlp"] = new Dictionary<string, object>
                    {
                        ["grpc"] = new Dictionary<string, object>
                        {
                            ["enabled"] = true
                        }
                    }
                },
                ["storage"] = new Dictionary<string, object>
                {
                    ["trace"] = new Dictionary<string, object>
                    {
                        ["backend"] = "s3",
                        ["s3"] = new Dictionary<string, object>
                        {
                            ["bucket"] = "tempo",
                            ["endpoint"] = "shared-minio:9000",
                            ["access_key"] = "o11yuser",
                            ["secret_key"] = "o11ypassword",
                            ["insecure"] = true
                        }
                    }
                },
                ["ingester"] = new Dictionary<string, object>
                {
                    ["config"] = new Dictionary<string, object>
                    {
                        ["replication_factor"] = 1
                    },
                    ["resources"] = new Dictionary<string, object>
                    {
                        ["limits"] = new Dictionary<string, object>
                        {
                            ["cpu"] = "500m",
                            ["memory"] = "500Mi"
                        },
                        ["requests"] = new Dictionary<string, object>
                        {
                            ["cpu"] = "100m",
                            ["memory"] = "128Mi"
                        }
                    }
                },
                ["minio"] = new InputMap<object>
                {
                    ["enabled"] = false
                },
                ["distributor"] = new InputMap<object>
                {
                    ["config"] = new InputMap<object>
                    {
                        ["log_received_traces"] = true,
                        ["log_received_spans"] = new InputMap<object>
                        {
                            ["enabled"] = true,
                            ["include_all_attributes"] = true,
                            ["filter_by_status_error"] = true
                        }
                    }
                },
                ["memberlist"] = new InputMap<object>
                {
                    ["gossip_nodes"] = 1
                }
            };
            
            var tempo = new Release("tempo", new ReleaseArgs
            {
                Name = "tempo-distributed",
                Chart = "tempo-distributed",
                // helm search repo grafana/tempo-distributed --versions | head -n 5
                Version = "1.2.10",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                Values = values,
                RecreatePods = true,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                Atomic = true
            }, new CustomResourceOptions { DependsOn = new[] { input.MinIoRelease } });
            
            return new TempoComponentOutput();
        }
    }
}