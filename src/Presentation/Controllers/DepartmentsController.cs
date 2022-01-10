using System.Text.Json;
using MessagePipe;
using Microsoft.AspNetCore.Mvc;
using UseCase.Departments;
using UseCase.Departments.Find;
using ZLogger;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly ILogger<DepartmentsController> _logger;
    private readonly IRequestHandler<IDepartmentsInputData, IDepartmentsOutputData> _departmentsUseCaseHandler;
    
    public DepartmentsController(ILogger<DepartmentsController> logger, IRequestHandler<IDepartmentsInputData, IDepartmentsOutputData> departmentsUseCaseHandler)
    {
        _logger = logger;
        _departmentsUseCaseHandler = departmentsUseCaseHandler;
    }

    [HttpGet]
    public IActionResult List()
    {
        var findDepartmentsInputData = new FindDepartmentsInputData();
        var departmentsOutputData = _departmentsUseCaseHandler.Invoke(findDepartmentsInputData);

        _logger.ZLogInformation("[FindDepartments] serialized string is: " + JsonSerializer.Serialize((FindDepartmentsOutputData)departmentsOutputData));

        var findManyDepartmentsInputData = new FindManyDepartmentsInputData();
        var findManyDepartmentsOutputData = _departmentsUseCaseHandler.Invoke(findManyDepartmentsInputData);
        _logger.ZLogInformation("[FindManyDepartments]  serialized string is : " + JsonSerializer.Serialize((FindManyDepartmentsOutputData)findManyDepartmentsOutputData));

        return new JsonResult(departmentsOutputData) { StatusCode = StatusCodes.Status200OK };
    }
}