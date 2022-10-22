using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.ContainerRegistry.Resource
{
    public class MinIO
    {
        private readonly ILogger<MinIO> _logger;
        private Config _config;

        public MinIO(ILogger<MinIO> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public Output<string> Apply(Input<string> namespaceName)
        {
            // ref: https://github.com/minio/minio/blob/master/helm/minio/values.yaml
            var values = new Dictionary<string, object>
            {
                ["replicas"] = 1,
                ["persistence"] = new Dictionary<string, object>
                {
                    ["size"] = "1Gi"
                },
                ["ingress"] = new Dictionary<string, object>
                {
                    ["enabled"] = true,
                    ["hosts"] = new List<object>
                    {
                        "api.minio.cr.test"
                    }
                },
                ["consoleIngress"] = new Dictionary<string, object>
                {
                    ["enabled"] = true,
                    ["hosts"] = new List<string>
                    {
                        "console.minio.cr.test"
                    }
                },
                ["resources"] = new Dictionary<string, object>
                {
                    ["requests"] = new Dictionary<string, object>
                    {
                        ["memory"] = "200Mi" 
                    }
                },
                ["rootUser"] = "minioadmin",
                ["rootPassword"] = "minioadmin",
                ["users"] = new List<object>
                {
                    new Dictionary<string, object>
                    {
                        ["accessKey"] = "harbor",
                        ["secretKey"] = "harbor1234",
                        ["policy"] = "readwrite"
                    }
                },
                ["buckets"] = new List<object>
                {
                    new Dictionary<string, object>
                    {
                        ["name"] = "container-registry",
                        ["policy"] = "public",
                        ["purge"] = false,
                        ["versioning"] = false
                    }
                }
            };

            if (_config.IsMinikube())
            {
                values.TryAdd("nodeSelector", new Dictionary<string, object>
                {
                    ["kubernetes.io/hostname"] = "minikube"
                });
                values.TryAdd("makeBucketJob", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        ["kubernetes.io/hostname"] = "minikube"
                    }
                });
                values.TryAdd("makePolicyJob", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        ["kubernetes.io/hostname"] = "minikube"
                    }
                });
                values.TryAdd("makeUserJob", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        ["kubernetes.io/hostname"] = "minikube"
                    }
                });
                values.TryAdd("customCommandJob", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        ["kubernetes.io/hostname"] = "minikube"
                    }
                });
            }
            
            var release = new Release("container-registry-minio", new ReleaseArgs
            {
                Name = "minio",
                Chart = "minio",
                // helm search repo minio/minio --versions
                Version = "4.0.15",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.min.io"
                },
                Namespace = namespaceName,
                Atomic = true,
                Values = values
            });
            return release.Values.Apply(x => (string)((ImmutableArray<object>)((ImmutableDictionary<string, object>)x["consoleIngress"])["hosts"]).First());
        }
    }
}