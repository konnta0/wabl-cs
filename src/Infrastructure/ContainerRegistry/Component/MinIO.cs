using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.ContainerRegistry.Component
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
                ["replicas"] = 4,
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
                values.TryAdd("makeBucketJob", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        ["kubernetes.io/hostname"] = "minikube"
                    }
                });
            }
            
            var release = new Release("minio", new ReleaseArgs
            {
                Chart = "minio",
                // helm search repo minio/minio --versions
                // NAME            CHART VERSION   APP VERSION                     DESCRIPTION
                // minio/minio     4.0.0           RELEASE.2022-04-26T01-20-24Z    Multi-Cloud Object Storage
                // minio/minio     3.6.6           RELEASE.2022-04-16T04-26-02Z    Multi-Cloud Object Storage
                Version = "4.0.2",
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