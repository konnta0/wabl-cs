using Microsoft.AspNetCore.Mvc;
using Presentation.Filter;

namespace Presentation.Core;

[ServiceFilter(typeof(TransactionalFlowFilter))]
public class WebApiController : ControllerBase
{
    
}