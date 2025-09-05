using EventMaster.DTOs;
using EventMaster.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: api/admin/pending-organizers
        [HttpGet("pending-organizers")]
        public async Task<IActionResult> GetPendingOrganizers()
        {
            var organizers = await _adminService.GetPendingOrganizersAsync();
            return Ok(organizers);
        }

        // POST: api/admin/approve-organizer/5?approve=true
        /* [HttpPost("approve-organizer/{userId}")]
         public async Task<IActionResult> ApproveOrganizer(int userId, [FromQuery] bool approve)
         {
             var result = await _adminService.ApproveOrganizerAsync(userId, approve);
             if (!result) return NotFound("Organizer not found.");
             return Ok("Organizer approval updated.");
         }*/
        [HttpPost("approve-organizer/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ApproveOrganizer(int userId, [FromQuery] bool approve)
        {
            var result = await _adminService.ApproveOrganizerAsync(userId, approve);
            if (!result)
                return BadRequest("Could not process organizer approval/rejection");

            return Ok(approve ? "Organizer approved successfully" : "Organizer rejected successfully");
        }



        // GET: api/admin/pending-events
        [HttpGet("pending-events")]
        public async Task<IActionResult> GetPendingEvents()
        {
            var events = await _adminService.GetPendingEventsAsync();
            return Ok(events);
        }

        // POST: api/admin/approve-event/5?approve=true
        /*[HttpPost("approve-event/{eventId}")]
        public async Task<IActionResult> ApproveEvent(int eventId, [FromQuery] bool approve)
        {
            var result = await _adminService.ApproveEventAsync(eventId, approve);
            if (!result) return NotFound("Event not found.");
            return Ok("Event approval updated.");
        }*/
        [HttpPost("approve-event/{eventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ApproveEvent(int eventId, [FromQuery] bool approve)
        {
            var result = await _adminService.ApproveEventAsync(eventId, approve);
            if (!result)
                return BadRequest("Could not process event approval/rejection");

            return Ok(approve ? "Event approved successfully" : "Event rejected successfully");
        }

    }
}
