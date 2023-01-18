using Infrastructure.Component.Shared.CiCd.Tekton;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Component.Shared.CiCd
{
    public class CiCdComponent : IComponent<CiCdComponentInput, CiCdComponentOutput>
    {
        private readonly ILogger<CiCdComponent> _logger;
        private Config _config;
        private readonly TektonComponent _tekton;

        public CiCdComponent(ILogger<CiCdComponent> logger, Config config, TektonComponent tekton)
        {
            _logger = logger;
            _config = config;
            _tekton = tekton;
        }

        public CiCdComponentOutput Apply(CiCdComponentInput input)
        {
            _tekton.Apply(new TektonComponentInput
            {
                Namespace = input.Namespace
            });
            return new CiCdComponentOutput();
        }
    }
}