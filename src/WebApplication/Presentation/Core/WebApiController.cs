using Microsoft.AspNetCore.Mvc;
using Presentation.Filter;

namespace Presentation.Core;

[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
[ServiceFilter(typeof(TransactionalFlowFilter))]
[ServiceFilter(typeof(ContinuousProfilerFilter))]
public class WebApiController : ControllerBase
{
}