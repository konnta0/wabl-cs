using MessagePipe;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extension.ResponseDataFactory.Departments;
using UseCase.Core.RequestHandler;
using UseCase.Departments;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly ILogger<DepartmentsController> _logger;
    private readonly IUseCaseHandler _useCaseHandler;
    
    public DepartmentsController(ILogger<DepartmentsController> logger, IUseCaseHandler useCaseHandler)
    {
        _logger = logger;
        _useCaseHandler = useCaseHandler;
    }

    [HttpGet]
    public async ValueTask<IActionResult> List()
    {
        var listDepartmentsInputData = new ListDepartmentsUseCaseInput();
        var listDepartmentsOutputData = await _useCaseHandler.InvokeAsync<ListDepartmentsUseCaseInput, ListDepartmentsUseCaseOutput>(listDepartmentsInputData);
        var responseData = ListResponseDataFactory.Create(listDepartmentsOutputData);
        return Ok(responseData);
    }
}