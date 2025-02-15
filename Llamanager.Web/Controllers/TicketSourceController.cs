using Llamanager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Llamanager.Web.Controllers;

[Route("/ticket-source")]
public class TicketSourceController(IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TicketSource))]
    public IActionResult GetSource()
    {
        return Ok(new TicketSource(configuration.TicketSource()));
    }
}