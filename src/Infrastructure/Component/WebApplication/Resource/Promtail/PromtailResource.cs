using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructure.Extension;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.WebApplication.Resource.Promtail
{
    public class PromtailResource
    {
        private readonly Config _config;

        public PromtailResource(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            var values = new Dictionary<string, object>
            {
                ["daemonset"] = new Dictionary<string, object>
                {
                    ["enabled"] = true
                },
                ["deployment"] = new Dictionary<string, object>
                {
                    ["enabled"] = false
                },
                ["configmap"] = new Dictionary<string, object>
                {
                    ["enabled"] = false
                },
                ["config"] = new Dictionary<string, object>
                {
                    ["clients"] = new InputList<InputMap<string>>
                    {
                        new InputMap<string>
                        {
                            {"url", "http://loki-distributed-distributor.observability.svc.cluster.local:3100/loki/api/v1/push"}
                        }
                    }
                }
            };
            var promtail = new Release("web-application-promtail", new ReleaseArgs
            {
                Name = "promtail",
                Chart = "promtail",
                // helm search repo grafana/promtail --versions | head -n 5
                // NAME                    CHART VERSION   APP VERSION     DESCRIPTION
                // grafana/promtail        6.4.0           2.6.1           Promtail is an agent which ships the contents o...
                // grafana/promtail        6.3.1           2.6.1           Promtail is an agent which ships the contents o...
                // grafana/promtail        6.3.0           2.6.1           Promtail is an agent which ships the contents o...
                // grafana/promtail        6.2.3           2.6.1           Promtail is an agent which ships the contents o...
                Version = "6.4.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                CreateNamespace = false,
                Atomic = true,
                Values = values,
                Namespace = _config.GetWebApplicationConfig().Namespace,
                RecreatePods = true
            });
        }
    }
}