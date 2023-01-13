using System.Collections.Generic;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Certmanager.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.Component.Shared.ContainerRegistry.Harbor
{
    public class HarborComponent : IComponent<HarborComponentInput, HarborComponentOutput>
    {
        private readonly ILogger<HarborComponent> _logger;
        private Config _config;

        public HarborComponent(ILogger<HarborComponent> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public HarborComponentOutput Apply(HarborComponentInput input)
        {
            var certificate = new Pulumi.Crds.Certmanager.V1.Certificate("harbor-certificate", new CertificateArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "harbor",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new CertificateSpecArgs
                {
                    Subject = new CertificateSpecSubjectArgs
                    {
                        Organizations = { "MyOrg" },
                        Countries = { "Japan" },
                        OrganizationalUnits = { "MyUnit" },
                        Localities = "Kanagawa",
                        Provinces = "Yokohama"
                    },
                    CommonName = "harbor-cn",
                    Duration = "8760h",
                    DnsNames = { "cr.test", "'*.harbor.cr.test'" },
                    SecretName = "harbor-certificate",
                    IssuerRef = new CertificateSpecIssuerrefArgs
                    {
                        Name = input.Issuer.Metadata.Apply(x => x.Name),
                        Kind = nameof(Issuer),
                        Group = "cert-manager.io"
                    },
                    PrivateKey = new CertificateSpecPrivatekeyArgs
                    {
                        Algorithm = "RSA",
                        Size = 2048
                    }
                }
            });

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
                            ["secretName"] = certificate.Spec.Apply(x => x.SecretName)
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
                Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                Atomic = true,
                Values = values,
                Timeout = 60 * 10
            });
            return new HarborComponentOutput();
        }
    }
}