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

            new ConfigFile("certificate-harbor", new ConfigFileArgs
            {
                File = "Resource/Shared/Certificate/Yaml/harbor.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            }).Ready();
            
            // ref: https://github.com/goharbor/harbor-helm/blob/master/values.yaml
            var values = new Dictionary<string, object>
            {
                ["expose"] = new InputMap<object>
                {
                    ["tls"] = new InputMap<object>
                    {
                        ["enabled"] = true,
                        ["certSource"] = "secret",
                        ["secret"] = new InputMap<object>
                        {
                            ["secretName"] = "harbor-certificate"
                        }
                    },
                    ["ingress"] = new InputMap<object>
                    {
                        ["hosts"] = new InputMap<object>
                        {
                            ["core"] = "core.harbor.cr.test",
                            ["notary"] = "notary.harbor.cr.test"
                        }
                    }
                },
                ["externalURL"] = "https://core.harbor.cr.test",
                ["harborAdminPassword"] = "Harbor1234",
                // ["persistence"] = new InputMap<object>
                // {
                //     ["persistentVolumeClaim"] = new InputMap<object>
                //     {
                //         ["database"] = new InputMap<object>
                //         {
                //             ["accessMode"] = "ReadWriteMany"
                //         }
                //     }
                //     // https://github.com/goharbor/harbor-helm/issues/1217
                //     // ["imageChartStorage"] = new InputMap<object>
                //     // {
                //     //     ["disableredirect"] = false,
                //     //     ["type"] = "s3",
                //     //     ["s3"] = new InputMap<object>
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
                values.TryAdd("notary", new InputMap<object>
                {
                    ["server"] = new InputMap<object>
                    {
                        ["nodeSelector"] = new InputMap<object>
                        {
                            [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                        }
                    },
                    ["signer"] = new InputMap<object>
                    {
                        ["nodeSelector"] = new InputMap<object>
                        {
                            [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                        }
                    }
                });
                values.TryAdd("trivy", new InputMap<object>
                {
                    ["nodeSelector"] = new InputMap<object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("core", new InputMap<object>
                {
                    ["nodeSelector"] = new InputMap<object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("jobservice", new InputMap<object>
                {
                    ["nodeSelector"] = new InputMap<object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("registry", new InputMap<object>
                {
                    ["nodeSelector"] = new InputMap<object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("chartmuseum", new InputMap<object>
                {
                    ["nodeSelector"] = new InputMap<object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("portal", new InputMap<object>
                {
                    ["nodeSelector"] = new InputMap<object>
                    {
                        [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                    }
                });
                values.TryAdd("database", new InputMap<object>
                {
                    ["internal"] = new InputMap<object>
                    {
                        ["nodeSelector"] = new InputMap<object>
                        {
                            [containerRegistryConfig.Harbor.NodeSelector.Label] = containerRegistryConfig.Harbor.NodeSelector.Value
                        }
                    }
                });
                values.TryAdd("redis", new InputMap<object>
                {
                    ["internal"] = new InputMap<object>
                    {
                        ["nodeSelector"] = new InputMap<object>
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