using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Services;

namespace EventMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<Event>>> GetUpcomingEvents()
        {
            var events = await _eventService.GetUpcomingEventsAsync();
            return Ok(events);
        }

        [HttpGet("organizer/{organizerId}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsByOrganizer(int organizerId)
        {
            var events = await _eventService.GetEventsByOrganizerAsync(organizerId);
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            var ev = await _eventService.GetEventByIdAsync(id);
            if (ev == null) return NotFound();
            return Ok(ev);
        }

        /*[HttpPost]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] EventDTO dto)
        {
            var ev = await _eventService.CreateEventAsync(dto);
            return CreatedAtAction(nameof(GetEventById), new { id = ev.EventId }, ev);
        }*/
        [HttpPost]
        [ProducesResponseType(typeof(EventDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EventDTO>> Create([FromBody] EventDTO dto)
        {
            var createdEvent = await _eventService.CreateEventAsync(dto);
            if (createdEvent == null)
                return BadRequest("Could not create event");

            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.EventId }, createdEvent);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEvent(int id, [FromBody] EventDTO dto)
        {
            var ev = await _eventService.UpdateEventAsync(id, dto);
            if (ev == null) return NotFound();
            return Ok(ev);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var deleted = await _eventService.DeleteEventAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}


