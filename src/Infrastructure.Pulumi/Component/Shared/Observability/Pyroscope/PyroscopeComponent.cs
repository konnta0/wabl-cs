using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Pyroscope
{
    public class PyroscopeComponent : IComponent<PyroscopeComponentInput, PyroscopeComponentOutput>
    {
        private readonly ILogger<PyroscopeComponent> _logger;
        private readonly Config _config;

        public PyroscopeComponent(ILogger<PyroscopeComponent> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }
        
        public PyroscopeComponentOutput Apply(PyroscopeComponentInput input)
        {
            const string config = @"
storage:
  backend: s3
  s3:
    endpoint: shared-minio:9000
    bucket_name: pyroscope
    access_key_id: o11yuser
    secret_access_key: o11ypassword
    insecure: true";
            
            // https://github.com/grafana/pyroscope/blob/main/operations/pyroscope/helm/pyroscope/values.yaml
            var values = new InputMap<object>
            {
                ["minio"] = new InputMap<object>
                {
                    ["enabled"] = false
                },
                ["pyroscope"] = new InputMap<object>
                {
                    ["config"] = config,
                    ["components"] = new InputMap<object>
                    {
                        ["querier"] = new InputMap<object>
                        {
                            { "kind", "Deployment" },
                            { "replicaCount", 1 },
                            {
                                "resources", new InputMap<object>
                                {
                                    ["limits"] = new InputMap<object>
                                    {
                                        { "memory", "1Gi" }
                                    },
                                    ["requests"] = new InputMap<object>
                                    {
                                        { "memory", "256Mi" },
                                        { "cpu", "500m" }
                                    }
                                }
                            }
                        },
                        ["query-frontend"] = new InputMap<object>
                        {
                            { "kind", "Deployment" },
                            { "replicaCount", 2 },
                            {
                                "resources", new InputMap<object>
                                {
                                    ["limits"] = new InputMap<object>
                                    {
                                        { "memory", "1Gi" }
                                    },
                                    ["requests"] = new InputMap<object>
                                    {
                                        { "memory", "256Mi" },
                                        { "cpu", "100m" }
                                    }
                                }
                            }
                        },
                        ["query-scheduler"] = new InputMap<object>
                        {
                            { "kind", "Deployment" },
                            { "replicaCount", 1 },
                            {
                                "resources", new InputMap<object>
                                {
                                    ["limits"] = new InputMap<object>
                                    {
                                        { "memory", "1Gi" }
                                    },
                                    ["requests"] = new InputMap<object>
                                    {
                                        { "memory", "256Mi" },
                                        { "cpu", "200m" }
                                    }
                                }
                            }
                        },
                        ["distributor"] = new InputMap<object>
                        {
                            { "kind", "Deployment" },
                            { "replicaCount", 1 },
                            {
                                "resources", new InputMap<object>
                                {
                                    ["limits"] = new InputMap<object>
                                    {
                                        { "memory", "1Gi" }
                                    },
                                    ["requests"] = new InputMap<object>
                                    {
                                        { "memory", "256Mi" },
                                        { "cpu", "200m" }
                                    }
                                }
                            }
                        },
                        ["ingester"] = new InputMap<object>
                        {
                            { "kind", "StatefulSet" },
                            { "replicaCount", 1 },
                            {"terminationGracePeriodSeconds", "600"},
                            {
                                "resources", new InputMap<object>
                                {
                                    ["limits"] = new InputMap<object>
                                    {
                                        { "memory", "1Gi" }
                                    },
                                    ["requests"] = new InputMap<object>
                                    {
                                        { "memory", "1Gi" },
                                        { "cpu", "200m" }
                                    }
                                }
                            }
                        },
                        ["store-gateway"] = new InputMap<object>
                        {
                            { "kind", "StatefulSet" },
                            { "replicaCount", 1 },
                            { "persistence", new InputMap<object>
                            {
                                ["enabled"] = false
                            }},
                            {
                                "resources", new InputMap<object>
                                {
                                    ["limits"] = new InputMap<object>
                                    {
                                        { "memory", "1Gi" }
                                    },
                                    ["requests"] = new InputMap<object>
                                    {
                                        { "memory", "1Gi" },
                                        { "cpu", "200m" }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            
            var pyroscope = new Release("pyroscope", new ReleaseArgs
            {
                Name = "pyroscope",
                Chart = "pyroscope",
                // helm search repo grafana/pyroscope --versions | head -n 5
                Version = "1.0.1",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                Values = values,
                Atomic = true,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            });
            return new PyroscopeComponentOutput();
        }
    }
}