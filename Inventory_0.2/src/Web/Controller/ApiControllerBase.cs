using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Inventory_0._2.Web.WebUI.Controllers;
[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
