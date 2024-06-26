using System.Collections.Generic;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Promtail
{
    public class PromtailComponent : IComponent<PromtailComponentInput, PromtailComponentOutput>
    {
        private readonly Config _config;

        public PromtailComponent(Config config)
        {
            _config = config;
        }
        
        public PromtailComponentOutput Apply(PromtailComponentInput input)
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
                            {"url", "http://loki-distributed-distributor.shared.svc.cluster.local:3100/loki/api/v1/push"}
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
                Version = "6.10.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                CreateNamespace = false,
                Atomic = true,
                Values = values,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                RecreatePods = true
            });
            
            return new PromtailComponentOutput();
        }
    }
}