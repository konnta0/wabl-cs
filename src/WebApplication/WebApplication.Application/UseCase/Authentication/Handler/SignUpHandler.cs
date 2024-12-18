using WebApplication.Application.Core.Authentication;
using WebApplication.Application.Core.RepositoryHandler;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.UseCase.Authentication.DataTransferObject;
using WebApplication.Application.UseCase.Authentication.ExecutionResult;

namespace WebApplication.Application.UseCase.Authentication.Handler;

internal sealed class SignUpHandler(
    IUseCaseActivityStarter activityStarter,
    IAuthenticationProvider authenticationProvider,
    IRepositoryHandler repositoryHandler)
    : AsyncUseCaseRequestHandlerBase<SignUpUseCaseInput, SignUpExecuteResult>(activityStarter)
{
    protected override ValueTask ValidateAsync(SignUpUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        return ValueTask.CompletedTask;
    }

    protected override async ValueTask<SignUpExecuteResult> ExecuteAsync(SignUpUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        var result = await authenticationProvider.SignUpAsync(input.UserName, input.Password, cancellationToken);
        if (result.ResultType is not SignUpResultType.Success)
        {
            throw new InvalidOperationException($"Sign up failed. {result}");
        }

        return new SignUpExecuteResult();
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(SignUpUseCaseInput input, SignUpExecuteResult executionResult,
        CancellationToken cancellationToken = new ())
    {
        return new ValueTask<IUseCaseOutput>(new SignUpUseCaseOutput());
    }
}