using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly ILogger<DepartmentsController> _logger;
    
    public DepartmentsController(ILogger<DepartmentsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult List()
    {
        var outputData = new object();
        return new JsonResult(outputData) { StatusCode = StatusCodes.Status200OK };
    }
}