using System.Text;
using Llamanager.Engine;
using Llamanager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Llamanager.Web.Controllers;

[Route("/release-request")]
[ApiController]
public class ReleaseRequestController(OllamaClient ollamaClient, SseSessionPool sseSessionPool): ControllerBase
{
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Submit([FromBody] ReleaseRequest releaseRequest, CancellationToken cancellationToken)
    {
        var eventStream = sseSessionPool.TryGetEventStream(HttpContext);
        var response = ollamaClient.GetResponse(releaseRequest.Message, cancellationToken);
        if(eventStream != null)
        {
            response = response.Tee(eventStream.SendToken);
        }
        var answer = new StringBuilder();
        await foreach(var token in response)
        {
            answer.Append(token);
        }
        return Ok(new ReleaseRequestResponse(answer.ToString()));
    }
}