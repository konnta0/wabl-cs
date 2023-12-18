using Infrastructure.Pulumi.Component.Shared;
using Infrastructure.Pulumi.Component.Tool;
using Infrastructure.Pulumi.Component.WebApplication;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Pulumi.Stack
{
    public class LocalStack : global::Pulumi.Stack
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