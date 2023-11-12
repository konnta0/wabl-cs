using Application.Core.RequestHandler;
using Application.UseCase.Authentication.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Core;
using Presentation.Dto.Request;

namespace Presentation.Controllers;


[ApiController]
public sealed class AuthenticationsController : WebApiController
{
    private readonly IUseCaseHandler _useCaseHandler;

    public AuthenticationsController(IUseCaseHandler useCaseHandler)
    {
        _useCaseHandler = useCaseHandler;
    }

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
        await _useCaseHandler.InvokeAsync<SignUpUseCaseInput, SignUpUseCaseOutput>(input, cancellationToken);
    }
}