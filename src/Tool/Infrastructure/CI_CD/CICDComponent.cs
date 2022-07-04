using Infrastructure.CI_CD.Resource.Tekton;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.CI_CD
{
    public class CICDComponent
    {
        private readonly ILogger<CICDComponent> _logger;
        private Config _config;
        private readonly TektonResource _tekton;

        public CICDComponent(ILogger<CICDComponent> logger, Config config, TektonResource tekton)
        {
            _logger = logger;
            _config = config;
            _tekton = tekton;
        }

        public void Apply()
        {
            _ = new Namespace("ci-cd-namespace", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = _config.GetCICDConfig().Namespace
                }
            });
            _tekton.Apply();
        }
    }
}