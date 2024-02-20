using WebApplication.Application.Core.Authentication;
using WebApplication.Application.Core.RepositoryHandler;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.UseCase.Authentication.Dto;
using WebApplication.Application.UseCase.Authentication.ExecuteResult;

namespace WebApplication.Application.UseCase.Authentication;

internal sealed class SignUpHandler(
    IUseCaseActivityStarter activityStarter,
    IAuthenticationProvider authenticationProvider,
    IRepositoryHandler repositoryHandler)
    : AsyncUseCaseRequestHandlerBase<SignUpUseCaseInput, SignUpExecuteResult>(activityStarter)
{
    private readonly IRepositoryHandler _repositoryHandler = repositoryHandler;


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

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(SignUpUseCaseInput input, SignUpExecuteResult executeResult,
        CancellationToken cancellationToken = new ())
    {
        return new ValueTask<IUseCaseOutput>(new SignUpUseCaseOutput());
    }
}