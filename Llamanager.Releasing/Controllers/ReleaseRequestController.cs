using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;
using Llamanager.Releasing.Domain;
using Llamanager.Releasing.Models;
using Llamanager.Releasing.Repository;
using Llamanager.Tickets.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReleaseRequest = Llamanager.Releasing.Models.ReleaseRequest;

namespace Llamanager.Releasing.Controllers;

[ApiController]
[Route("/release-request")]
public class ReleaseRequestController(
    IJudgementService judgementService,
    IReleaseRequestRepository releaseRequestRepository, 
    ITicketRepository ticketRepository
) : ControllerBase
{
    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReleaseSummary>))]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var releaseRequests = await releaseRequestRepository.GetAll(cancellationToken);
        return Ok(releaseRequests.Select(rr => new ReleaseSummary(rr)));
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReleaseRequest))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public async Task<IActionResult> Get([FromRoute] string id, CancellationToken cancellationToken)
    {
        var releaseRequest = await releaseRequestRepository.Get(WebUtility.UrlDecode(id), cancellationToken);
        if (releaseRequest != null)
        {
            return Ok(new ReleaseRequest(releaseRequest));
        }
        return NotFound();
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReleaseRequest))]
    public async Task<IActionResult> Create([FromBody] CreateReleaseRequest createReleaseRequest, CancellationToken cancellationToken)
    {
        var tickets = await GetTicketSummaries(createReleaseRequest.Tickets, cancellationToken).ToArrayAsync(cancellationToken);
        var releaseRequest = Domain.ReleaseRequest.Create(tickets, createReleaseRequest.ReleaseNotes, createReleaseRequest.Consequences, createReleaseRequest.Countermeasures);
        await releaseRequestRepository.Add(releaseRequest, cancellationToken);
        return Ok(new ReleaseRequest(releaseRequest));
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReleaseRequest))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateReleaseRequest updateReleaseRequest, CancellationToken cancellationToken)
    {
        var releaseRequest = await releaseRequestRepository.Get(WebUtility.UrlDecode(id), cancellationToken);
        if(releaseRequest == null)
        {
            return NotFound();
        }
        var tickets = await GetTicketSummaries(updateReleaseRequest.Tickets, cancellationToken).ToArrayAsync(cancellationToken);
        releaseRequest.Update(tickets, updateReleaseRequest.ReleaseNotes, updateReleaseRequest.Consequences, updateReleaseRequest.Countermeasures);
        await releaseRequestRepository.Update(releaseRequest, cancellationToken);
        return Ok(new ReleaseRequest(releaseRequest));
    }

    private async IAsyncEnumerable<ITicket> GetTicketSummaries(List<string> ticketIds, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach(var id in ticketIds)
        {
            var ticket = await ticketRepository.GetSummaryById(id, cancellationToken);
            if(ticket == null) throw new ValidationException($"Ticket {id} did not exist");
            yield return ticket;
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public async Task<IActionResult> Delete([FromRoute] string id, CancellationToken cancellationToken)
    {
        var ticket = await releaseRequestRepository.Get(WebUtility.UrlDecode(id), cancellationToken);
        if(ticket == null)
        {
            return NotFound();
        }
        await releaseRequestRepository.Delete(ticket, cancellationToken);
        return Ok();
    }

    [HttpPost]
    [Route("{id}/judge")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReleaseRequest))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public async Task<IActionResult> RequestJudgement([FromRoute] string id, CancellationToken cancellationToken)
    {
        var releaseRequest = await releaseRequestRepository.Get(WebUtility.UrlDecode(id), cancellationToken);
        if(releaseRequest == null)
        {
            return NotFound();
        }
        await judgementService.Judge(releaseRequest, cancellationToken);
        await releaseRequestRepository.Update(releaseRequest, cancellationToken);
        return Ok(new ReleaseRequest(releaseRequest));
    }

    
}