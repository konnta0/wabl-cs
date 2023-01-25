using System.Collections.Generic;
using Infrastructure.Extension;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Component.Shared.Storage.MinIo
{
    public class MinIoComponent : IComponent<MinIoComponentInput, MinIoComponentOutput>
    {
        private readonly Config _config;

        public MinIoComponent(Config config)
        {
            _config = config;
        }

        public MinIoComponentOutput Apply(MinIoComponentInput input)
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
                        "api.minio.storage.test"
                    }
                },
                ["consoleIngress"] = new Dictionary<string, object>
                {
                    ["enabled"] = true,
                    ["hosts"] = new List<string>
                    {
                        "console.minio.storage.test"
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
                    },
                    new InputMap<object>
                    {
                        ["accessKey"] = "mimir",
                        ["secretKey"] = "mimirsecret",
                        ["policy"] = "readwrite"
                    }
                },
                ["buckets"] = new List<object>
                {
                    new InputMap<object>
                    {
                        ["name"] = "tempo",
                        ["policy"] = "public",
                        ["purge"] = false,
                        ["versioning"] = false
                    },
                    new InputMap<object>
                    {
                        ["name"] = "mimir-ruler",
                        ["policy"] = "public",
                        ["purge"] = false,
                        ["versioning"] = false
                    },
                    new InputMap<object>
                    {
                        ["name"] = "mimir-tsdb",
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
            
            var release = new Release("shared-minio", new ReleaseArgs
            {
                Name = "shared-minio",
                Chart = "minio",
                // helm search repo minio/minio --versions
                Version = "4.0.15",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.min.io"
                },
                CreateNamespace = true,
                Namespace = input.Namespace.Metadata.Apply(_ => _.Name),
                Atomic = true,
                Values = values
            });

            return new MinIoComponentOutput();
        }
    }
}