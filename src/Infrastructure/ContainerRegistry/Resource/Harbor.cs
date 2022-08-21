using System.Collections.Generic;
using System.Collections.Immutable;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.ContainerRegistry.Resource
{
    public class Harbor
    {
        private readonly ILogger<Harbor> _logger;
        private Config _config;
        private Input<string> _namespaceName;

        public Harbor(ILogger<Harbor> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public Output<string> Apply(Input<string> namespaceName)
        {
            _namespaceName = namespaceName;

            _ = new ConfigFile("certificate-harbor", new ConfigFileArgs
            {
                File = "./Certificate/Resource/Yaml/harbor.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });
            
            // ref: https://github.com/goharbor/harbor-helm/blob/master/values.yaml
            var values = new Dictionary<string, object>
            {
                ["expose"] = new Dictionary<string, object>
                {
                    ["tls"] = new Dictionary<string, object>
                    {
                        ["enabled"] = true,
                        ["certSource"] = "secret",
                        ["secret"] = new Dictionary<string, object>
                        {
                            ["secretName"] = "harbor-certificate",
                        }
                    },
                    ["ingress"] = new Dictionary<string, object>
                    {
                        ["hosts"] = new Dictionary<string, object>
                        {
                            ["core"] = "core.harbor.cr.test",
                            ["notary"] = "notary.harbor.cr.test"
                        }
                    }
                },
                ["externalURL"] = "https://core.harbor.cr.test",
                ["harborAdminPassword"] = "Harbor1234",
                // ["persistence"] = new Dictionary<string, object>
                // {
                //     ["persistentVolumeClaim"] = new Dictionary<string, object>
                //     {
                //         ["database"] = new Dictionary<string, object>
                //         {
                //             ["accessMode"] = "ReadWriteMany"
                //         }
                //     }
                //     // https://github.com/goharbor/harbor-helm/issues/1217
                //     // ["imageChartStorage"] = new Dictionary<string, object>
                //     // {
                //     //     ["disableredirect"] = false,
                //     //     ["type"] = "s3",
                //     //     ["s3"] = new Dictionary<string, object>
                //     //     {
                //     //         ["region"] = "us-east-1",
                //     //         ["accesskey"] = "harbor",
                //     //         ["secretkey"] = "harbor1234",
                //     //         ["regionendpoint"] = "http://api.minio.cr.test",
                //     //         ["bucket"] = "container-registry",
                //     //         ["secure"] = false,
                //     //         ["v4auth"] = true,
                //     //         ["encrypt"] = false,
                //     //         ["chunksize"] = "5242880",
                //     //         ["rootdirectory"] = "/"
                //     //     }
                //     // }
                //  }
            };

            if (_config.IsMinikube())
            {
                var containerRegistryConfig = _config.GetContainerRegistryConfig();
                values.TryAdd("notary", new Dictionary<string, object>
                {
                    ["server"] = new Dictionary<string, object>
                    {
                        ["nodeSelector"] = new Dictionary<string, object>
                        {
                            [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                        }
                    },
                    ["signer"] = new Dictionary<string, object>
                    {
                        ["nodeSelector"] = new Dictionary<string, object>
                        {
                            [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                        }
                    }
                });
                values.TryAdd("trivy", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("core", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("jobservice", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("registry", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("chartmuseum", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("portal", new Dictionary<string, object>
                {
                    ["nodeSelector"] = new Dictionary<string, object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("database", new Dictionary<string, object>
                {
                    ["internal"] = new Dictionary<string, object>
                    {
                        ["nodeSelector"] = new Dictionary<string, object>
                        {
                            [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                        }
                    }
                });
                values.TryAdd("redis", new Dictionary<string, object>
                {
                    ["internal"] = new Dictionary<string, object>
                    {
                        ["nodeSelector"] = new Dictionary<string, object>
                        {
                            [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                        }
                    }
                });
            }
            
            var harbor = new Release("harbor", new ReleaseArgs
            {
                Chart = "harbor",
                // https://github.com/goharbor/harbor-helm/releases/tag/v1.9.1
                Version = "v1.9.1",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://helm.goharbor.io"
                },
                Namespace = _namespaceName,
                Atomic = true,
                Values = values,
                Timeout = 60 * 10
            });
            return harbor.Values.Apply(x => (string)x["externalURL"]);
        }
        
        private ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (!metadata.ContainsKey("namespace")) return obj;
            return obj.SetItem("metadata", metadata.SetItem("namespace", _namespaceName));
        }
    }
}