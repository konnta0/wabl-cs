using Infrastructure.Component.Shared.CiCd.GitHubActions;
using Infrastructure.Component.Shared.CiCd.Spinnaker;
using Infrastructure.Component.Shared.CiCd.Tekton;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Component.Shared.CiCd
{
    public sealed class CiCdComponent : IComponent<CiCdComponentInput, CiCdComponentOutput>
    {
        private readonly ILogger<CiCdComponent> _logger;
        private Config _config;
        private readonly TektonComponent _tekton;
        private readonly SpinnakerComponent _spinnaker;
        private readonly GitHubActionsComponent _gitHubActionsComponent;

        public CiCdComponent(
            ILogger<CiCdComponent> logger, 
            Config config, 
            TektonComponent tekton,
            SpinnakerComponent spinnaker, GitHubActionsComponent gitHubActionsComponent)
        {
            _logger = logger;
            _config = config;
            _tekton = tekton;
            _spinnaker = spinnaker;
            _gitHubActionsComponent = gitHubActionsComponent;
        }

        public CiCdComponentOutput Apply(CiCdComponentInput input)
        {
            // _tekton.Apply(new TektonComponentInput
            // {
            //     Namespace = input.Namespace
            // });
            // _spinnaker.Apply(new SpinnakerComponentInput
            // {
            //     Namespace = input.Namespace
            // });

            _gitHubActionsComponent.Apply(new GitHubActionsComponentInput
            {
                Namespace = input.Namespace,
                WithActContainer = true
            });
            return new CiCdComponentOutput();
        }
    }
}