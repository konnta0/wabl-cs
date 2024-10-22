using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Config = Pulumi.Config;

namespace Infrastructure.Pulumi.Component.Shared.Observability.SigNoz
{
    public class SigNozComponent(ILogger<SigNozComponent> logger, Config config)
        : IComponent<SigNozComponentInput, SigNozComponentOutput>
    {
        private readonly ILogger<SigNozComponent> _logger = logger;
        private readonly Config _config = config;

        public SigNozComponentOutput Apply(SigNozComponentInput input)
        {
            var mimir = new Release("signoz", new ReleaseArgs
            {
                Name = "signoz",
                Chart = "signoz",
                // helm search repo grafana/mimir-distributed --versions | head -n 5
                Version = "0.53.1",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.signoz.io"
                },
                
                Atomic = true,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            });
            return new SigNozComponentOutput();
        }
    }
}