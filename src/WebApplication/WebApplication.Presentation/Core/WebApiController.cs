using Microsoft.AspNetCore.Mvc;
using WebApplication.Presentation.Filter;

namespace WebApplication.Presentation.Core;

[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
[ServiceFilter(typeof(TransactionalFlowFilter))]
[ServiceFilter(typeof(ContinuousProfilerFilter))]
public class WebApiController : ControllerBase;