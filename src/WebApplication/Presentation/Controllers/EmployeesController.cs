using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.Departments.Dto;
using WebApplication.Application.UseCase.Departments.Dto;
using Domain.RestApi.Departments;
using Microsoft.AspNetCore.Mvc;
using Presentation.Core;
using Presentation.Extension.ResponseDataFactory.Departments;

namespace Presentation.Controllers;

[ApiController]
public class EmployeesController : WebApiController
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly IUseCaseHandler _useCaseHandler;
    
    public EmployeesController(ILogger<EmployeesController> logger, IUseCaseHandler useCaseHandler)
    {
        _logger = logger;
        _useCaseHandler = useCaseHandler;
    }

    [HttpGet("departments")]
    public async ValueTask<IActionResult> ListDepartments()
    {
        var listDepartmentsInput = new ListDepartmentsUseCaseInput();
        var listDepartmentsOutput = await _useCaseHandler.InvokeAsync<ListDepartmentsUseCaseInput, ListDepartmentsUseCaseOutput>(listDepartmentsInput);
        var responseData = ListResponseFactory.Create(listDepartmentsOutput);
        return Ok(responseData);
    }

    [HttpPost("departments")]
    [ProducesResponseType(typeof(AddResponse), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> AddDepartments([FromBody] AddRequest request)
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