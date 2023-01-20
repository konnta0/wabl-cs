using System.Collections.Generic;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Config = Pulumi.Config;

namespace Infrastructure.Component.Shared.Observability.Tempo
{
    public class TempoComponent
    {
        private readonly ILogger<TempoComponent> _logger;
        private readonly Config _config;

        public TempoComponent(ILogger<TempoComponent> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public void Apply()
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
                            ["endpoint"] = "minio:9000",
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
                    }
                },
                ["minio"] = new InputMap<object>
                {
                    ["enabled"] = false
                }
            };

            var tempo = new Release("tempo-distributed", new ReleaseArgs
            {
                Name = "tempo-distributed",
                Chart = "tempo-distributed",
                // helm search repo grafana/tempo-distributed --versions | head -n 5
                // NAME                            CHART VERSION   APP VERSION     DESCRIPTION
                // grafana/tempo-distributed       0.19.0          1.4.1           Grafana Tempo in MicroService mode
                // grafana/tempo-distributed       0.18.2          1.4.1           Grafana Tempo in MicroService mode
                // grafana/tempo-distributed       0.18.1          1.4.1           Grafana Tempo in MicroService mode
                // grafana/tempo-distributed       0.18.0          1.4.1           Grafana Tempo in MicroService mode
                Version = "0.26.5",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                Values = values,
                CreateNamespace = true,
                RecreatePods = true,
                Namespace = _config.GetObservabilityConfig().Namespace
            });
        }
    }
}