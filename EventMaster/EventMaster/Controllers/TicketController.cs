using EventMaster.DTOs;
using EventMaster.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // POST: api/ticket
        /*[HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketDTO ticketDto)
        {
            try
            {
                var ticket = await _ticketService.CreateTicketAsync(ticketDto);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }*/
        [HttpPost]
        [ProducesResponseType(typeof(TicketDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TicketDTO>> Create([FromBody] TicketDTO dto)
        {
            var ticket = await _ticketService.CreateTicketAsync(dto);
            if (ticket == null)
                return BadRequest("Could not create ticket");

            return CreatedAtAction(nameof(GetTicketsByEventId), new { eventId = ticket.EventId }, ticket);
        }


        // GET: api/ticket/event/5
        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetTicketsByEventId(int eventId)
        {
            var tickets = await _ticketService.GetTicketsByEventIdAsync(eventId);
            return Ok(tickets);
        }

        // GET: api/ticket/participant/3
        [HttpGet("participant/{participantId}")]
        public async Task<IActionResult> GetTicketsByParticipantId(int participantId)
        {
            var tickets = await _ticketService.GetTicketsByParticipantIdAsync(participantId);
            return Ok(tickets);
        }
    }
}

