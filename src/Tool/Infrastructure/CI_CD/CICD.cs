using Infrastructure.CI_CD.Component;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.CI_CD
{
    public class CICD
    {
        private readonly ILogger<CICD> _logger;
        private Config _config;
        private readonly Tekton _tekton;

        public CICD(ILogger<CICD> logger, Config config, Tekton tekton)
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