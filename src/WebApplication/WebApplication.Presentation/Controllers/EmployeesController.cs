using WebApplication.Application.Core.RequestHandler;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Application.UseCase.Departments.DataTransferObject;
using WebApplication.Domain.RestApi.Departments;
using WebApplication.Presentation.Core;
using WebApplication.Presentation.Extension.ResponseDataFactory.Departments;

namespace WebApplication.Presentation.Controllers;

[ApiController]
public class EmployeesController(ILogger<EmployeesController> logger, IUseCaseHandler useCaseHandler)
    : WebApiController
{

    [HttpGet("departments")]
    public async ValueTask<IActionResult> ListDepartments()
    {
        var listDepartmentsInput = new ListDepartmentsUseCaseInput();
        var listDepartmentsOutput = await useCaseHandler.InvokeAsync<ListDepartmentsUseCaseInput, ListDepartmentsUseCaseOutput>(listDepartmentsInput);
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
        var addDepartmentOutput = await useCaseHandler.InvokeAsync<AddDepartmentsUseCaseInput, AddDepartmentsUseCaseOutput>(addDepartmentInput);
        var responseData = AddResponseFactory.Create(addDepartmentOutput);
        return Ok(responseData);
    }
}