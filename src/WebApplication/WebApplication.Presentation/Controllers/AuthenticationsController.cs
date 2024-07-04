using WebApplication.Application.Core.RequestHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Application.UseCase.Authentication.DataTransferObject;
using WebApplication.Presentation.Core;
using WebApplication.Presentation.Dto.Request;

namespace WebApplication.Presentation.Controllers;


[ApiController]
public sealed class AuthenticationsController(IUseCaseHandler useCaseHandler) : WebApiController
{
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public ValueTask SignIn()
    {
        throw new NotImplementedException();
    }
    

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async ValueTask SignUp(
        [FromBody] SignUpRequest request,
        CancellationToken cancellationToken
        )
    {
        var input = new SignUpUseCaseInput
        {
            UserName = request.UserName,
            Password = request.Password
        };
        await useCaseHandler.InvokeAsync<SignUpUseCaseInput, SignUpUseCaseOutput>(input, cancellationToken);
    }
}