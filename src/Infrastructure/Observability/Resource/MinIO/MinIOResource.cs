using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Infrastructure.Extension;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Observability.Resource.MinIO
{
    public class MinIOResource
    {
        private readonly Config _config;

        public MinIOResource(Config config)
        {
            _config = config;
        }


        public Output<string> Apply()
        {
            // ref: https://github.com/minio/minio/blob/master/helm/minio/values.yaml
            var values = new Dictionary<string, object>
            {
                ["replicas"] = 2,
                ["persistence"] = new Dictionary<string, object>
                {
                    ["size"] = "1Gi"
                },
                ["ingress"] = new Dictionary<string, object>
                {
                    ["enabled"] = true,
                    ["hosts"] = new List<object>
                    {
                        "api.minio.o11y.test"
                    }
                },
                ["consoleIngress"] = new Dictionary<string, object>
                {
                    ["enabled"] = true,
                    ["hosts"] = new List<string>
                    {
                        "console.minio.o11y.test"
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
                        ["accessKey"] = "o11yuser",
                        ["secretKey"] = "o11ypassword",
                        ["policy"] = "readwrite"
                    }
                },
                ["buckets"] = new List<object>
                {
                    new Dictionary<string, object>
                    {
                        ["name"] = "tempo",
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
            
            var release = new Release("observability-minio", new ReleaseArgs
            {
                Name = "minio",
                Chart = "minio",
                // helm search repo minio/minio --versions
                Version = "4.0.15",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.min.io"
                },
                Namespace = _config.GetObservabilityConfig().Namespace,
                Atomic = true,
                Values = values
            });
            return release.Values.Apply(x => (string)((ImmutableArray<object>)((ImmutableDictionary<string, object>)x["consoleIngress"])["hosts"]).First());
        }
    }
}