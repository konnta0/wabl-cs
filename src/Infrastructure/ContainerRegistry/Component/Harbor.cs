using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.ContainerRegistry.Component
{
    public class Harbor
    {
        private readonly ILogger<Harbor> _logger;
        private Config _config;

        public Harbor(ILogger<Harbor> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public void Apply()
        {
            new ConfigFile("container-registry-certificate", new ConfigFileArgs
            {
                File = "./Certificate/yaml/ca/Certificate.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });

            new ConfigFile("container-registry-issuer", new ConfigFileArgs
            {
                File = "./Certificate/yaml/ca/Issuer.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });
            
            new ConfigFile("certificate-harbor", new ConfigFileArgs
            {
                File = "./Certificate/yaml/harbor.yaml",
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
                // https://github.com/goharbor/harbor-helm/issues/1217
                // ["persistence"] = new Dictionary<string, object>
                // {
                //     ["imageChartStorage"] = new Dictionary<string, object>
                //     {
                //         ["disableredirect"] = false,
                //         ["type"] = "s3",
                //         ["s3"] = new Dictionary<string, object>
                //         {
                //             ["region"] = "us-east-1",
                //             ["accesskey"] = "harbor",
                //             ["secretkey"] = "harbor1234",
                //             ["regionendpoint"] = "http://api.minio.cr.test",
                //             ["bucket"] = "container-registry",
                //             ["secure"] = false,
                //             ["v4auth"] = true,
                //             ["encrypt"] = false,
                //             ["chunksize"] = "5242880",
                //             ["rootdirectory"] = "/"
                //         }
                //     }
                //  }
            };
            
            HarborExternalUrl = Output<string>.Create(Task.FromResult<string>("dummy"));
            var harbor = new Release("harbor", new ReleaseArgs
            {
                Chart = "harbor",
                // https://github.com/goharbor/harbor-helm/releases/tag/v1.9.1
                Version = "v1.9.1",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://helm.goharbor.io"
                },
                CreateNamespace = true,
                Atomic = true,
                Namespace = Define.Namespace,
                Values = values
            });
            HarborExternalUrl = harbor.Values.Apply(x => (string)x["externalURL"]);
        }
        
        private ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (!metadata.ContainsKey("namespace")) return obj;
            return obj.SetItem("metadata", metadata.SetItem("namespace", Define.Namespace));
        }

        [Output] public Output<string> HarborExternalUrl { get; private set; }
    }
}