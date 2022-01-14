using MessagePipe;
using Microsoft.AspNetCore.Mvc;
using UseCase.Departments;
using UseCase.Departments.List;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly ILogger<DepartmentsController> _logger;
    private readonly IAsyncRequestHandler<IDepartmentsInputData, IDepartmentsOutputData> _departmentsUseCaseHandler;
    
    public DepartmentsController(ILogger<DepartmentsController> logger, IAsyncRequestHandler<IDepartmentsInputData, IDepartmentsOutputData> departmentsUseCaseHandler)
    {
        _logger = logger;
        _departmentsUseCaseHandler = departmentsUseCaseHandler;
    }

    [HttpGet]
    public async ValueTask<IActionResult> List()
    {
        var listDepartmentsInputData = new ListDepartmentsInputData();
        var listDepartmentsOutputData = await _departmentsUseCaseHandler.InvokeAsync(listDepartmentsInputData);

        return new JsonResult(listDepartmentsOutputData) { StatusCode = StatusCodes.Status200OK };
    }
}