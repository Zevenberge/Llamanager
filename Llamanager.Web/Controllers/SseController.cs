using Microsoft.AspNetCore.Mvc;

namespace Llamanager.Web.Controllers;

[Route("/sse")]
[ApiExplorerSettings(IgnoreApi = true)]
public class SseController(SseSessionPool sseSessionPool): ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task Connect()
    {
        await sseSessionPool.AddOpenedEventStream(HttpContext);
    }
}
