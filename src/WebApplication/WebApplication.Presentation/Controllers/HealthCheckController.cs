using Microsoft.AspNetCore.Mvc;
using WebApplication.Presentation.Core;
using ZLogger;

namespace WebApplication.Presentation.Controllers;

[ApiController]
public class HealthCheckController(ILogger<HealthCheckController> logger) : WebApiController
{
    [HttpGet]
    public IActionResult Ping()
    {
        logger.ZLogInformation("Called ping");
        return new JsonResult("pong") { StatusCode = 200 };
    }
}