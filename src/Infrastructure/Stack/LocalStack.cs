using Infrastructure.Component.Shared;
using Infrastructure.Component.Tool;
using Infrastructure.Component.WebApplication;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Stack
{
    public class LocalStack : Pulumi.Stack
    {
        private readonly ILogger<LocalStack> _logger;

        public LocalStack(
            ILogger<LocalStack> logger, 
            WebApplicationComponent webApplicationComponent,
            SharedComponent sharedComponent,
            ToolComponent toolComponent)
        {
            _logger = logger;
            _logger.LogInformation("start development stack");

            sharedComponent.Apply(new SharedComponentInput());
            //GitLabHost = versionControlSystemComponent.Apply();
            webApplicationComponent.Apply(new WebApplicationComponentInput());
            toolComponent.Apply(new ToolComponentInput());
        }

    }
}