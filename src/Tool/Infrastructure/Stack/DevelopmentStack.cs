using Infrastructure.CI_CD.Tekton;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Stack
{
    public class DevelopmentStack : Pulumi.Stack
    {
        private readonly ILogger<DevelopmentStack> _logger;

        public DevelopmentStack(ILogger<DevelopmentStack> logger, Config config, Tekton tekton)
        {
            _logger = logger;
            _logger.LogInformation("start development stack");
            var isMinikube = config.IsMinikube();
            
            tekton.Apply();
        }
    }
}