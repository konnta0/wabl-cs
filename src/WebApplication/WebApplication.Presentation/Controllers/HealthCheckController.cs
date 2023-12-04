using Microsoft.AspNetCore.Mvc;
using WebApplication.Presentation.Core;
using ZLogger;

namespace WebApplication.Presentation.Controllers;

[ApiController]
public class HealthCheckController : WebApiController
{
    private readonly ILogger<HealthCheckController> _logger;

    public HealthCheckController(ILogger<HealthCheckController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Ping()
    {
        _logger.ZLogInformation("Called ping");
        return new JsonResult("pong") { StatusCode = 200 };
    }
}