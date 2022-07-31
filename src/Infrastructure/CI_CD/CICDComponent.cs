using Infrastructure.CI_CD.Resource.Tekton;
using Microsoft.Extensions.Logging;
using Pulumi;

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
            _tekton.Apply();
        }
    }
}