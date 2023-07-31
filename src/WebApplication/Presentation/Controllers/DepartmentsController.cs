using Domain.RestApi.Departments;
using Microsoft.AspNetCore.Mvc;
using Presentation.Core;
using Presentation.Extension.ResponseDataFactory.Departments;
using UseCase.Core.RequestHandler;
using UseCase.Departments.Dto;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DepartmentsController : WebApiController
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
        var listDepartmentsInput = new ListDepartmentsUseCaseInput();
        var listDepartmentsOutput = await _useCaseHandler.InvokeAsync<ListDepartmentsUseCaseInput, ListDepartmentsUseCaseOutput>(listDepartmentsInput);
        var responseData = ListResponseFactory.Create(listDepartmentsOutput);
        return Ok(responseData);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Add([FromBody] AddRequest request)
    {
        var addDepartmentInput = new AddDepartmentsUseCaseInput
        {
            DepotNo = request.DepotNo,
            DeptName = request.DeptName
        };
        var addDepartmentOutput = await _useCaseHandler.InvokeAsync<AddDepartmentsUseCaseInput, AddDepartmentsUseCaseOutput>(addDepartmentInput);
        var responseData = AddResponseFactory.Create(addDepartmentOutput);
        return Ok(responseData);
    }
}