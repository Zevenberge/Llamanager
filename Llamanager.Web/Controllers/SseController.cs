using Microsoft.AspNetCore.Mvc;

namespace Llamanager.Web.Controllers;

[Route("/sse")]
public class SseController(SseSessionPool sseSessionPool): ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task Connect()
    {
        await sseSessionPool.AddOpenedEventStream(HttpContext);
    }
}
