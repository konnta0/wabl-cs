using Microsoft.AspNetCore.Mvc;
using Presentation.Core;
using ZLogger;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
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