using EventMaster.DTOs;
using EventMaster.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedEventController : ControllerBase
    {
        private readonly ISavedEventService _savedEventService;

        public SavedEventController(ISavedEventService savedEventService)
        {
            _savedEventService = savedEventService;
        }

        // POST: api/savedevents
        /*[HttpPost]
        public async Task<IActionResult> SaveEvent([FromBody] SavedEventDTO dto)
        {
            var savedEvent = await _savedEventService.SaveEventAsync(dto);
            return CreatedAtAction(nameof(GetSavedEventById), new { id = savedEvent.SavedEventId }, savedEvent);
        }*/
        [HttpPost]
        [ProducesResponseType(typeof(SavedEventDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SavedEventDTO>> Create([FromBody] SavedEventDTO dto)
        {
            var saved = await _savedEventService.SaveEventAsync(dto);
            if (saved == null)
                return BadRequest("Could not save event");

            return CreatedAtAction(nameof(GetSavedEventById), new { id = saved.SavedEventId }, saved);
        }



        // GET: api/savedevents/user/3
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetSavedEventsByUser(int userId)
        {
            var savedEvents = await _savedEventService.GetSavedEventsByUserIdAsync(userId);
            return Ok(savedEvents);
        }

        // GET: api/savedevents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSavedEventById(int id)
        {
            var savedEvent = await _savedEventService.GetSavedEventByIdAsync(id);
            if (savedEvent == null) return NotFound();

            return Ok(savedEvent);
        }

        // DELETE: api/savedevents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavedEvent(int id)
        {
            var result = await _savedEventService.DeleteSavedEventAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
