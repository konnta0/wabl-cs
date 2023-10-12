using Infrastructure.Component.Shared.CiCd.Spinnaker;
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
        private readonly SpinnakerComponent _spinnaker;

        public CiCdComponent(
            ILogger<CiCdComponent> logger, 
            Config config, 
            TektonComponent tekton,
            SpinnakerComponent spinnaker)
        {
            _logger = logger;
            _config = config;
            _tekton = tekton;
            _spinnaker = spinnaker;
        }

        public CiCdComponentOutput Apply(CiCdComponentInput input)
        {
            // _tekton.Apply(new TektonComponentInput
            // {
            //     Namespace = input.Namespace
            // });
            _spinnaker.Apply(new SpinnakerComponentInput
            {
                Namespace = input.Namespace
            });
            return new CiCdComponentOutput();
        }
    }
}