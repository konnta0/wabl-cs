using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;

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

        public void Apply()
        {
            // ref: https://github.com/minio/minio/blob/master/helm/minio/values.yaml
            var values = new Dictionary<string, object>
            {
                ["replicas"] = 4,
                ["persistence"] = new Dictionary<string, object>
                {
                    ["size"] = "10Gi"
                },
                ["ingress"] = new Dictionary<string, object>
                {
                    ["enabled"] = false
                },
                ["resources"] = new Dictionary<string, object>
                {
                    ["requests"] = new Dictionary<string, object>
                    {
                        ["memory"] = "1Gi" 
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

            var minio = new Release("minio", new ReleaseArgs
            {
                Chart = "minio",
                // helm search repo minio/minio --versions
                // NAME            CHART VERSION   APP VERSION                     DESCRIPTION
                // minio/minio     4.0.0           RELEASE.2022-04-26T01-20-24Z    Multi-Cloud Object Storage
                // minio/minio     3.6.6           RELEASE.2022-04-16T04-26-02Z    Multi-Cloud Object Storage
                Version = "3.6.6",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.min.io"
                },
                CreateNamespace = true,
                Atomic = true,
                Namespace = Define.Namespace,
                Timeout = 60 * 10,
                Values = values
            });
            
            var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("minio-container-registry-ingress", new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "minio-ingress",
                    Namespace = minio.Namespace
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "nginx",
                    Rules = new List<IngressRuleArgs>
                    {
                        new IngressRuleArgs
                        {
                            Host = "minio.cr.test",
                            Http = new HTTPIngressRuleValueArgs
                            {
                                Paths = new HTTPIngressPathArgs
                                {
                                    Path = "/",
                                    PathType = "Prefix",
                                    Backend = new IngressBackendArgs
                                    {
                                        Service = new IngressServiceBackendArgs
                                        {
                                            Name = minio.ResourceNames.Apply(x => x["Service/v1"].First(y => y.Contains("console")).Replace(Define.Namespace+"/", "")),
                                            Port = new ServiceBackendPortArgs { Number = 9001 }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}