using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

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
            var values = new Dictionary<string, object>
            {
                ["expose"] = new Dictionary<string, object>
                {
                    ["tls"] = new Dictionary<string, object>
                    {
                        ["enabled"] = false
                    },
                    ["ingress"] = new Dictionary<string, object>
                    {
                        ["annotations"] = new Dictionary<string, object>
                        {
                            ["ingress.kubernetes.io/ssl-redirect"] = "false",
                            ["ingress.kubernetes.io/proxy-body-size"] = "0",
                            ["nginx.ingress.kubernetes.io/ssl-redirect"] = "false",
                            ["nginx.ingress.kubernetes.io/proxy-body-size"] = "0"
                        },
                        ["hosts"] = new Dictionary<string, object>
                        {
                            ["core"] = "core.harbor.cr.test",
                            ["notary"] = "notary.harbor.cr.test"
                        }
                    }
                },
                ["externalURL"] = "http://core.harbor.cr.test",
                ["harborAdminPassword"] = "Harbor1234",
                ["persistence"] = new Dictionary<string, object>
                {
                    ["imageChartStorage"] = new Dictionary<string, object>
                    {
                        ["type"] = "s3"
                    },
                    ["s3"] = new Dictionary<string, object>
                    {
                        ["accesskey"] = "harbor",
                        ["secretkey"] = "harbor1234",
                        ["regionendpoint"] = "http://minio-0b9c79dd.container-registry.svc.cluster.local",
                        ["bucket"] = "harbor",
                        ["secure"] = false,
                        ["v4auth"] = true
                    }
                }
            };
            
            var harbor = new Release("harbor", new ReleaseArgs
            {
                Chart = "harbor",
                // https://github.com/goharbor/harbor-helm/releases/tag/v1.9.0
                Version = "v1.9.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://helm.goharbor.io"
                },
                CreateNamespace = true,
                Atomic = true,
                Namespace = Define.Namespace,
                Values = values,
                Timeout = 60 * 10
            });
            HarborExternalUrl = harbor.Values.Apply(x => (string)x["externalURL"]);
        }
        [Output] public Output<string> HarborExternalUrl { get; private set; }
    }
}