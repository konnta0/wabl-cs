using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.UseCase.HealthCheck.DataTransferObject;
using WebApplication.Presentation.Core;
using WebApplication.Presentation.Extension.ResponseDataFactory.HealthChecks;
using ZLogger;

namespace WebApplication.Presentation.Controllers;

[ApiController]
public class HealthCheckController(ILogger<HealthCheckController> logger, IUseCaseHandler useCaseHandler) : WebApiController
{
    [HttpGet]
    public IActionResult Ping()
    {
        logger.ZLogInformation("Called ping");
        return new JsonResult("pong") { StatusCode = 200 };
    }

    [AllowAnonymous]
    [HttpGet]
    public async ValueTask<IActionResult> System()
    {
        var input = new GetSystemInfoUseCaseInput();
        var output = await useCaseHandler.InvokeAsync<GetSystemInfoUseCaseInput, GetSystemInfoUseCaseOutput>(input);
        var response = GetSystemInfoFactory.Create(output);
        return new JsonResult(response) { StatusCode = 200 };
    }
}