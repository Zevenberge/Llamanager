using System.Net;
using Llamanager.Tickets.SelfContained.Domain;
using Llamanager.Tickets.SelfContained.Models;
using Llamanager.Tickets.SelfContained.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Llamanager.Tickets.SelfContained.Controllers;

[ApiController]
[Route("/llama/ticket")]
public class LlamaTicketController(ILlamaTicketRepository ticketRepository) : ControllerBase
{
    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Ticket>))]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var tickets = await ticketRepository.GetAll(cancellationToken);
        return Ok(tickets.Select(t => new Ticket(t)));
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ticket))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public async Task<IActionResult> Get([FromRoute] string id, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.Get(WebUtility.UrlDecode(id), cancellationToken);
        if (ticket != null)
        {
            return Ok(new Ticket(ticket));
        }
        return NotFound();
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ticket))]
    public async Task<IActionResult> Create([FromBody] CreateTicket createTicket, CancellationToken cancellationToken)
    {
        var ticket = LlamaTicket.Create(createTicket.Type, createTicket.Summary, createTicket.Description, createTicket.AcceptanceCriteria);
        await ticketRepository.Add(ticket, cancellationToken);
        return Ok(new Ticket(ticket));
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ticket))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateTicket updateTicket, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.Get(WebUtility.UrlDecode(id), cancellationToken);
        if(ticket == null)
        {
            return NotFound();
        }
        ticket.Update(updateTicket.Summary, updateTicket.Description, updateTicket.AcceptanceCriteria);
        await ticketRepository.Update(ticket, cancellationToken);
        return Ok(new Ticket(ticket));
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public async Task<IActionResult> Delete([FromRoute] string id, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.Get(WebUtility.UrlDecode(id), cancellationToken);
        if(ticket == null)
        {
            return NotFound();
        }
        await ticketRepository.Delete(ticket, cancellationToken);
        return Ok();
    }

    [HttpPut]
    [Route("{id}/status")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ticket))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public async Task<IActionResult> UpdateStatus([FromRoute] string id, [FromBody] UpdateStatus updateStatus, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.Get(WebUtility.UrlDecode(id), cancellationToken);
        if(ticket == null)
        {
            return NotFound();
        }
        ticket.UpdateStatus(updateStatus.Status);
        await ticketRepository.Update(ticket, cancellationToken);
        return Ok(new Ticket(ticket));
    }
    
    [HttpPut]
    [Route("{id}/type")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ticket))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public async Task<IActionResult> UpdateTicketType([FromRoute] string id, [FromBody] UpdateTicketType updateTicketType, CancellationToken cancellationToken)
    {
        var ticket = await ticketRepository.Get(WebUtility.UrlDecode(id), cancellationToken);
        if(ticket == null)
        {
            return NotFound();
        }
        ticket.ChangeTicketType(updateTicketType.Type);
        await ticketRepository.Update(ticket, cancellationToken);
        return Ok(new Ticket(ticket));
    }
}